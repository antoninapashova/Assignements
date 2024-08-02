using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Categories.Dto;
using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoriesListQuery, IList<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<IList<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _unitOfWork.CategoryRepository.GetAllEntities();
                categories.ToList().ForEach(c => c.CreatedDate.ToString("MM/dd/yyyy"));

                return _mapper.Map<IList<CategoryDto>>(categories);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
