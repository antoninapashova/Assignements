using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.HobbyTags.Queries.GetTagById
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetTagByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await IsExist(request.Id);
                return _mapper.Map<TagDto>(tag); 
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task<Tag> IsExist(int id)
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(id);
            return tag ?? throw new NullReferenceException($"Tag with id: {id} doesn't exist!");
        }
    }
}
