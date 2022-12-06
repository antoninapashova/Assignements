using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Queries
{
    internal class GetSubCategoryListQueryHandler : IRequestHandler<GetSubCategoryListQuery, IEnumerable<HobbySubCategoryListVm>>
    {
        private readonly ISubCategoryRepository _repository;

        public GetSubCategoryListQueryHandler(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HobbySubCategoryListVm>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllEntitiesAsync();
            var subcategories = result.Select(subCategory =>
            new HobbySubCategoryListVm
            {
                 Name = subCategory.Name,
            });
            return await Task.FromResult(subcategories.ToList());
        }

    }
}
