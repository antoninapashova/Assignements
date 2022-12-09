using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<UserListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserListVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAllEntitiesAsync();

            IEnumerable<UserListVm> users = _mapper.Map<IEnumerable<UserListVm>>(result.ToList());
            return await Task.FromResult(users);
        }
    }
}
