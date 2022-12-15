using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.HobbyTags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Queries
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagQuery, IEnumerable<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TagRepository.GetAllEntitiesAsync();
            IEnumerable<TagDto> enumerable = _mapper.Map<IEnumerable<TagDto>>(result.ToList());

            return await Task.FromResult(enumerable);
        }
    }
}
