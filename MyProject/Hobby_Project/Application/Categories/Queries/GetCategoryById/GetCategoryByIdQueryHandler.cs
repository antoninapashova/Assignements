using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Categories.Dto;
using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
                if (category == null) throw new NullReferenceException("Category not found!");

                category.CreatedDate.ToString("MM/dd/yyyy");

                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
