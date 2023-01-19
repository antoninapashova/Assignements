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

namespace HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories
{
    public class GetSubCategoryListQueryHandler : IRequestHandler<GetSubCategoryListQuery, IEnumerable<HobbySubCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public GetSubCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = SingletonLogger.Instance;
        }

        public async Task<IEnumerable<HobbySubCategoryDto>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            try
            {
               IEnumerable<HobbySubCategory> result = await _unitOfWork.SubCategoryRepository.GetAllEntitiesAsync();
                  
                

                 List<HobbySubCategoryDto> subCategories = _mapper.Map<List<HobbySubCategoryDto>>(result.ToList());
                return await Task.FromResult(subCategories.ToList());

            }catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }
}
