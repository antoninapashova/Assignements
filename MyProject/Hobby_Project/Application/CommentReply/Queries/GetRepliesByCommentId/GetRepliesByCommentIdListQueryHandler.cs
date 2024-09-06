using Application.Logger;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId
{
    public class GetRepliesByCommentIdListQueryHandler : IRequestHandler<GetRepliesByCommentIdListQuery, IList<ReplyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetRepliesByCommentIdListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<IList<ReplyDto>> Handle(GetRepliesByCommentIdListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var replies = _unitOfWork.ReplyRepository.GetAllRepliesByCommentId(request.CommentId);
                return _mapper.Map<IList<ReplyDto>>(replies);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
