using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
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
                var hobby = IsExist(request.Id);
                return _mapper.Map<HobbyDto>(hobby);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        private async Task<HobbyEntity> IsExist(int id)
        {
            var hobby = await _unitOfWork.HobbyArticleRepository.GetByIdAsync(id);
            return hobby ?? throw new NullReferenceException($"Hobby with id: {id} does not exist!");
        }
    }
}
