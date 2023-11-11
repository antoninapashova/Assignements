using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using MediatR;

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

                var userEntity = _mapper.Map<UserEntity>(command);
                userEntity.Password = PasswordHasher.HashPassword(command.Password);
                userEntity.Role = "Admin";
                userEntity.Token = "";
                userEntity.RefreshToken = "";

                await _unitOfWork.UserRepository.Add(userEntity);
                await _unitOfWork.Save();

                return userEntity.Id;
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
