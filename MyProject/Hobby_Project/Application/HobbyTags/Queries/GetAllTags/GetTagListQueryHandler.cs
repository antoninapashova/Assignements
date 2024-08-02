using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.HobbyTags.Queries;
using MediatR;

namespace Application.HobbyTags.Queries
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, IEnumerable<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.TagRepository.GetAllEntities();
            var enumerable = _mapper.Map<IEnumerable<TagDto>>(result.ToList());

            return enumerable;
        }
    }
}
