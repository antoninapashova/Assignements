﻿using Application.Logger;
using Application.Repositories;
using AutoMapper;
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
                var newAccessToken = user.Token;
                var newRefreshToken = CreateRefreshToken();
                user.RefreshToken = newRefreshToken;

                await _unitOfWork.Save();

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
                new Claim(ClaimTypes.Name, $"{user.Username}" )
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

       public string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _unitOfWork.UserRepository.GetAllEntitiesAsync().Result.Any(a=>a.RefreshToken==refreshToken);

            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("veryverysecret.......");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;   

            if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("This is Invalid Token");
            }
            return principal;
        }
    }
}
