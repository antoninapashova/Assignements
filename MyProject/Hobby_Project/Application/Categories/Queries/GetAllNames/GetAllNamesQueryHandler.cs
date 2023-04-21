using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetAllNames
{
    public class GetAllNamesQueryHandler : IRequestHandler<GetAllNamesQuery, List<CategoryNameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetAllNamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<List<CategoryNameDto>> Handle(GetAllNamesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Category> categories =
                     await _unitOfWork.CategoryRepository.GetAllNamesAsync();
               
               var categoryListVms = 
                    _mapper.Map<List<CategoryNameDto>>(categories);
            
                return await Task.FromResult(categoryListVms.ToList());
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
