using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<HobbyCategory> categories = await _unitOfWork.CategoryRepository.GetAllEntitiesAsync();
            List<CategoryListVm> categoryListVms = _mapper.Map<List<CategoryListVm>>(categories.ToList());
            return await Task.FromResult(categoryListVms.ToList());
        }
    }
}
