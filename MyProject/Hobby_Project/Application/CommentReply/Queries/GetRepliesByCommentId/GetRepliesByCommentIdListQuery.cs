using MediatR;

namespace HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId
{
    public class GetRepliesByCommentIdListQuery : IRequest<List<ReplyDto>>
    {
        public int CommentId { get; set; }
    }
}
