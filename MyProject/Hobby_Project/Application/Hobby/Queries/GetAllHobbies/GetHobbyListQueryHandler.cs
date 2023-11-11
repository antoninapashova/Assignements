using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Hobby.Dto;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetAllUsers
{
    public class GetHobbyListQueryHandler : IRequestHandler<GetHobbyListQuery, IEnumerable<HobbyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHobbyListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HobbyDto>> Handle(GetHobbyListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HobbyArticleRepository.GetAllEntitiesAsync();
            var hobbyListVms = _mapper.Map<List<HobbyDto>>(result.ToList());
            return hobbyListVms;
        }
    }
}
