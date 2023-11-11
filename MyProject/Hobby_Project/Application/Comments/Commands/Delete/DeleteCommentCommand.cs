using MediatR;

namespace Application.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
