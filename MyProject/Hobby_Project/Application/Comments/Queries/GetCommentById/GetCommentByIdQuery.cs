using Application.Comments.Queries;
using MediatR;

namespace HobbyProject.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
