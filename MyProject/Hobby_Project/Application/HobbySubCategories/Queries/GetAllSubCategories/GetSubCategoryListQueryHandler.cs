using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories
{
    internal class GetSubCategoryListQueryHandler : IRequestHandler<GetSubCategoryListQuery, IEnumerable<HobbySubCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetSubCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HobbySubCategoryDto>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.SubCategoryRepository.GetAllEntitiesAsync();
            List<HobbySubCategoryDto> subCategories = _mapper.Map<List<HobbySubCategoryDto>>(result.ToList());
            return await Task.FromResult(subCategories);
        }
    }
}
