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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            UserVm users = _mapper.Map<UserVm>(result);
            return await Task.FromResult(users);
        }
    }
}
