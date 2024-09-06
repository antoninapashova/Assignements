using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryQuery, HobbySubCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _logger;

        public GetSubCategoryByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = SingletonLogger.Instance;
        }

        public async Task<HobbySubCategoryDto> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subCategory = IsExist(request.Id);
                return _mapper.Map<HobbySubCategoryDto>(subCategory);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        private async Task<SubCategory> IsExist(int id)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id);
            return subCategory ?? throw new NullReferenceException($"Hobby with id: {id} does not exist!");
        }
    }
}
