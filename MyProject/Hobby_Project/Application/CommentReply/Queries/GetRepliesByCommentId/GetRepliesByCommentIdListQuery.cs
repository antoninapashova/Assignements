using MediatR;

namespace HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId
{
    public class GetRepliesByCommentIdListQuery : IRequest<IList<ReplyDto>>
    {
        public int CommentId { get; set; }
    }
}
