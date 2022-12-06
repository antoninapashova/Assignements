using Application.Repositories;
using AutoMapper;
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
        private IMapper _mapper;
        public GetCategoryListQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllEntitiesAsync();
            List<CategoryListVm> categoryListVms = _mapper.Map<List<CategoryListVm>>(result);
            return await Task.FromResult(categoryListVms.ToList());
        }
    }
}
