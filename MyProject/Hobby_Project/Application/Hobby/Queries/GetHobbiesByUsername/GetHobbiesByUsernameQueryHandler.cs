using Application.Hobby.Queries;
using Application.Logger;
using Application.Repositories;
using AutoMapper;
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
                if (request == null)
                    throw new NullReferenceException("Hobby by Id query is null");

                var result = await _unitOfWork.HobbyArticleRepository.GetHobbyArticlesByUsername(request.Username);
                List<HobbyDto> hobbyVm = _mapper.Map<List<HobbyDto>>(result);
                return await Task.FromResult(hobbyVm);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
