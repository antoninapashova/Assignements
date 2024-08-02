using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Hobby.Dto;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetHobbiesByUsername
{
    public class GetHobbiesByUsernameQueryHandler : IRequestHandler<GetHobbiesByUsernameQuery, IEnumerable<HobbyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public GetHobbiesByUsernameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = SingletonLogger.Instance;
        }

        public async Task<IEnumerable<HobbyDto>> Handle(GetHobbiesByUsernameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _unitOfWork.HobbyArticleRepository.GetHobbyArticlesByUsername(request.Username);
                return _mapper.Map<IList<HobbyDto>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
