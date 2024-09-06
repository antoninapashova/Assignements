using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.User.Dto;
using HobbyProject.Application.User.Query.GetById;
using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.User.Query.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await IsExist(request.Id);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task<UserEntity> IsExist(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return user ?? throw new NullReferenceException($"User with ID: {id} does not exist!");
        }
    }
}
