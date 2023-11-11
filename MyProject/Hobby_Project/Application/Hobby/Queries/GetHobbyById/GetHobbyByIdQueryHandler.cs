using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Hobby.Dto;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetHobbyById
{
    public class GetHobbyByIdQueryHandler : IRequestHandler<GetHobbyByIdQuery, HobbyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public GetHobbyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = SingletonLogger.Instance;
        }

        public async Task<HobbyDto> Handle(GetHobbyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) 
                    throw new NullReferenceException("Hobby by Id query is null");

                var result = await _unitOfWork.HobbyArticleRepository.GetByIdAsync(request.Id);
                var hobbyVm = _mapper.Map<HobbyDto>(result);

                return hobbyVm;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
