using Application.Logger;
using Application.Repositories;
using FluentAssertions;
using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.Login
{

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,UserEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly ITokenManager _tokenManager;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, ITokenManager tokenManager)
        {
            _unitOfWork = unitOfWork;
            _tokenManager = tokenManager;
            _log = SingletonLogger.Instance;
        }

        public async Task<UserEntity> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
              if (command == null) throw new NullReferenceException("Login user command is null");

                var user = await _unitOfWork.UserRepository
                    .FindByUsername(command.Username);

                if (!PasswordHasher.VerifyPassword(command.Password, user.Password)) 
                    throw new NullReferenceException("Password is incorect!");

                user.Token = _tokenManager.CreateJwtToken(user);
                var newAccessToken = user.Token;
                var newRefreshToken = _tokenManager.CreateRefreshToken();
                
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiredTime = DateTime.Now.AddDays(5);
                await _unitOfWork.Save();

                return await Task.FromResult(user);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
         } 
    }
}
