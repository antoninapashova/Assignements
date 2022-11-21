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

        public Task<IEnumerable<HobbySubCategoryListVm>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            var subCategory = _repository.GetAllSubCategories().Select(subCategory =>
            new HobbySubCategoryListVm
            {
                
                Name = subCategory.Name,

            });
            return Task.FromResult(subCategory);
        }

    }
}
