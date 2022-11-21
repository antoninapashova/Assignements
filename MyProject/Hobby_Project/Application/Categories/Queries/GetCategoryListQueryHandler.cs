using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoriesListQuery, IEnumerable<CategoryListVm>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryListQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAllCategories().Select(category => new CategoryListVm
            {
                ID = category.ID,
                Name = category.Name,
                AddedOn = category.AddedOn,
                HobbySubCategories = category.HobbySubCategories.Select(sub => new HobbySubCategoryDTO
                {
                    Name = sub.Name,
                    AddedOn = sub.AddedOn

                }).ToList()
            });

            return Task.FromResult(result);
        }
    }
}
