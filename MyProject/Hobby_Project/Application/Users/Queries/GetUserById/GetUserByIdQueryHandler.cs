using Application.Logger;
using Application.Repositories;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetUserById
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
                if (request == null) 
                    throw new NullReferenceException("Get user by id query is null!");

              var result = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
              UserDto users = _mapper.Map<UserDto>(result);
              return await Task.FromResult(users);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
            
        }
    }
}
