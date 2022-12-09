using Application.Repositories;
using AutoMapper;
using Hobby_Project;
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
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<HobbyCategory> categories = await _unitOfWork.CategoryRepository.GetAllEntitiesAsync();
            List<CategoryListVm> categoryListVms = _mapper.Map<List<CategoryListVm>>(categories.ToList());
            return await Task.FromResult(categoryListVms);
        }
    }
}
