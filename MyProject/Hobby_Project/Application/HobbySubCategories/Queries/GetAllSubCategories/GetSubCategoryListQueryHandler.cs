using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories
{
    public class GetSubCategoryListQueryHandler : IRequestHandler<GetSubCategoryListQuery, IEnumerable<HobbySubCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _logger;

        public GetSubCategoryListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = SingletonLogger.Instance;
        }

        public async Task<IEnumerable<HobbySubCategoryDto>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _unitOfWork.SubCategoryRepository.GetAllEntities();
                var subCategories = new List<HobbySubCategoryDto>();

                foreach (var c in result)
                {
                    var subCategoryDto = new HobbySubCategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    };

                    subCategories.Add(subCategoryDto);
                }

                return subCategories.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
