using Application.Categories.Queries;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Queries
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagsListQuery, IEnumerable<TagListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagListVm>> Handle(GetTagsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TagRepository.GetAllEntitiesAsync();
            IEnumerable<TagListVm> enumerable = _mapper.Map<IEnumerable<TagListVm>>(result);

            return await Task.FromResult(enumerable);
        }
    }
}
