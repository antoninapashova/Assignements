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
               IEnumerable<SubCategory> result = await _unitOfWork.SubCategoryRepository.GetAllEntitiesAsync();
                List<HobbySubCategoryDto> subCategories = new List<HobbySubCategoryDto>();

                foreach (var c in result)
                {
                    var subCategoryDto = new HobbySubCategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    };
                    subCategories.Add(subCategoryDto);
                }

                return await Task.FromResult(subCategories.ToList());

            }catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }
}
