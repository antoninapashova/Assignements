using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryDto>>
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

        public async Task<List<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
               IEnumerable<Category> categories =
                    await _unitOfWork.CategoryRepository.GetAllEntitiesAsync();

                foreach(var el in categories)
                {
                     el.CreatedDate.ToString("MM/dd/yyyy");
                }

                List<CategoryDto> categoryListVms = 
                    _mapper.Map<List<CategoryDto>>(categories.ToList());
               
                return await Task.FromResult(categoryListVms);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
            
        }
    }
}
