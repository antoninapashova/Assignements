using Application.Repositories;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAllEntitiesAsync();

            IEnumerable<UserDto> users = _mapper.Map<IEnumerable<UserDto>>(result.ToList());
            return await Task.FromResult(users);
        }
    }
}
