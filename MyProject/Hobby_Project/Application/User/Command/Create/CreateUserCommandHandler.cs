using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HobbyProject.Application.User.Command.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create user command is null!");

                await IsUsernameExists(command.Username);

                await IsEmailExists(command.Email);

                UserEntity userEntity = _mapper.Map<UserEntity>(command);
                userEntity.Password = PasswordHasher.HashPassword(command.Password);
                userEntity.Role = "User";
                userEntity.Token = "";
                await _unitOfWork.UserRepository.Add(userEntity);
                await _unitOfWork.Save();

                return await Task.FromResult(userEntity.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
         }

        private async Task IsUsernameExists(string username)
        {
            bool isUsernameExists = await _unitOfWork.UserRepository.CheckUsernameExists(username);
            if (isUsernameExists) throw new NullReferenceException("User with that username already exists!");

        }

        private async Task IsEmailExists(string email)
        {
            bool isEmailExists = await _unitOfWork.UserRepository.CheckEmailExists(email);
            if (isEmailExists) throw new NullReferenceException("User with that email already exists");
        }
    }
}
