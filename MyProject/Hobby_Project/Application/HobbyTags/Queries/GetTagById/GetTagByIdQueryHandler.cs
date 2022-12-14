using Application.HobbyTags.Queries;
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

namespace HobbyProject.Application.HobbyTags.Queries.GetTagById
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ILog _log;
        public GetTagByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<TagVm> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.Id);
                var result = _mapper.Map<TagVm>(tag);
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult<TagVm>(null);
            }
        }
    }
}
