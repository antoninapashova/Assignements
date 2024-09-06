using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Comments.Dto;
using MediatR;

namespace HobbyProject.Application.Comments.Queries.GetCommentsByHobbyId
{
    public class GetCommentsByHobbyIdQueryHandler : IRequestHandler<GetCommentsByHobbyIdQuery, IList<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetCommentsByHobbyIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<IList<CommentDto>> Handle(GetCommentsByHobbyIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _unitOfWork.CommentRepository.GetCommentsByHobbyId(request.HobbyId);
                return _mapper.Map<IList<CommentDto>>(result);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
