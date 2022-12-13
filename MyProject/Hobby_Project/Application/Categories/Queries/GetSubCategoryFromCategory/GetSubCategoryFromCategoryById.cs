using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory
{
    public class GetSubCategoryFromCategoryById : IRequestHandler<GetSubCategoryFromCategory, CategoryWithSubCategoryVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ILog _log;
        public GetSubCategoryFromCategoryById(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<CategoryWithSubCategoryVm> Handle(GetSubCategoryFromCategory request, CancellationToken cancellationToken)
        {
            try
            {
                //Category with subcategories
                var result = await _unitOfWork.CategoryRepository.GetByIdAsync(request.HobbyCategotyId);

                //SubCategory
                var hobbySubCategory = result.HobbySubCategories.FirstOrDefault(x => x.Id == request.HobbySubCategotyId);
                HobbySubCategoryDTO hobbySubCategoryDTO = _mapper.Map<HobbySubCategoryDTO>(hobbySubCategory);

                CategoryWithSubCategoryVm categoryWithSubCategoryVm = _mapper.Map<CategoryWithSubCategoryVm>(result);
                categoryWithSubCategoryVm.HobbySubCategoryDTO = hobbySubCategoryDTO;

                return await Task.FromResult(categoryWithSubCategoryVm);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult<CategoryWithSubCategoryVm>(null);
            }
        }
    }
}
