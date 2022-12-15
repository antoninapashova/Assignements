using Application.Hobby.Queries;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Hobby.Queries.GetHobbyById
{
    public class GetHobbyByIdQueryHandler : IRequestHandler<GetHobbyByIdQuery, HobbyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHobbyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HobbyDto> Handle(GetHobbyByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HobbyArticleRepository.GetByIdAsync(request.Id);
            HobbyDto  hobbyVm = _mapper.Map<HobbyDto>(result);
            return await Task.FromResult(hobbyVm);
        }
    }
}
