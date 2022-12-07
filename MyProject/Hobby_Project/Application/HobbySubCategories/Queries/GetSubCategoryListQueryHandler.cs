using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Queries
{
    internal class GetSubCategoryListQueryHandler : IRequestHandler<GetSubCategoryListQuery, IEnumerable<HobbySubCategoryListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetSubCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
             _mapper = mapper;
        }

        public async Task<IEnumerable<HobbySubCategoryListVm>> Handle(GetSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result= await _unitOfWork.SubCategoryRepository.GetAllEntitiesAsync();
            List<HobbySubCategoryListVm> subCategories= _mapper.Map<List<HobbySubCategoryListVm>>(result);
            return await Task.FromResult(subCategories);
        }
    }
}
