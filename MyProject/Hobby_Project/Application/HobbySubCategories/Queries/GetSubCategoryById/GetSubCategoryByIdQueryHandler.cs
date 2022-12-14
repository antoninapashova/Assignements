using Application.Logger;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryQuery, HobbySubCategoryVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private ILog _logger;


        public GetSubCategoryByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = SingletonLogger.Instance;
        }

        public async Task<HobbySubCategoryVm> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
              var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(request.Id);
              HobbySubCategoryVm hobbySubCategoryVm = _mapper.Map<HobbySubCategoryVm>(subCategory);
               return await Task.FromResult(hobbySubCategoryVm);
            }catch(Exception e)
            {
                _logger.LogError(e.Message);
                return await Task.FromResult<HobbySubCategoryVm>(null);
            }
            
        }
    }
}
