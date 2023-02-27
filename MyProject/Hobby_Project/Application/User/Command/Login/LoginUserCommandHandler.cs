using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserEntity>
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

                var user = await _unitOfWork.UserRepository.FindByUsernameAndPassword(command.Username, command.Password);

                if(!PasswordHasher.VerifyPassword(command.Password, user.Password)) throw new NullReferenceException("Password is incorect!");

                return await Task.FromResult(user);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
            
        }
    }
}
