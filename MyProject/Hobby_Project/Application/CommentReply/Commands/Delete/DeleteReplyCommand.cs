using MediatR;

namespace HobbyProject.Application.CommentReply.Commands.Delete
{
    public class DeleteReplyCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
