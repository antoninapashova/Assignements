using MediatR;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int HobbyArticleId { get; set; }
    }
}
