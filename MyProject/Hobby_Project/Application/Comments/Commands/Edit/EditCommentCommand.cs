using MediatR;

namespace Application.Comments.Commands.Edit
{
    public class EditCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
    }
}
