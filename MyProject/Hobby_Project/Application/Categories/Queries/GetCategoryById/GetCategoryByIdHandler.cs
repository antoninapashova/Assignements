using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) 
                    throw new NullReferenceException("Get category by Id query is null!");

                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
                category.CreatedDate.ToString("MM/dd/yyyy");
                var result =  _mapper.Map<CategoryDto>(category);
                
                return await Task.FromResult(result);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
           
        }
    }
}
