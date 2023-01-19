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

namespace HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryQuery, HobbySubCategoryDto>
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

        public async Task<HobbySubCategoryDto> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    throw new NullReferenceException("Get subCategory query is null!");

                HobbySubCategory subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(request.Id);
                 HobbySubCategoryDto hobbySubCategoryVm = _mapper.Map<HobbySubCategoryDto>(subCategory);
                return await Task.FromResult(hobbySubCategoryVm);

            }catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }
}
