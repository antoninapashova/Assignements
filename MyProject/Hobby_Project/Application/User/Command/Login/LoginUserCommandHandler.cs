using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.Login
{

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,UserEntity >
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<UserEntity> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
              if (command == null) throw new NullReferenceException("Login user command is null");

                var user = await _unitOfWork.UserRepository
                    .FindByUsername(command.Username);
                
                if(!PasswordHasher.VerifyPassword(command.Password, user.Password)) throw new NullReferenceException("Password is incorect!");

                user.Token = CreateJwtToken(user);

                return await Task.FromResult(user);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
            
        } 
  
        private string CreateJwtToken(UserEntity user)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.......");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, $"{user.FirstName}, {user.LastName}" )
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

       
    }
}
