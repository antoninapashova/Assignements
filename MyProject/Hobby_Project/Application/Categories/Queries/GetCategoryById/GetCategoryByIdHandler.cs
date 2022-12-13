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

namespace HobbyProject.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ILog _log;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<CategoryListVm> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
                var result =  _mapper.Map<CategoryListVm>(category);
                return await Task.FromResult(result);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult<CategoryListVm>(null);
            }
           
        }
    }
}
