using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.CommentReply.Commands.Create
{
    public class CreateReplyCommand : IRequest<Reply>
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
