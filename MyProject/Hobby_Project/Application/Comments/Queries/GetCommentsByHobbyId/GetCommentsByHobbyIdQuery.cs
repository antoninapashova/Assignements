using Application.Comments.Queries;
using MediatR;

namespace HobbyProject.Application.Comments.Queries.GetCommentsByHobbyId
{
    public class GetCommentsByHobbyIdQuery : IRequest<List<CommentDto>>
    {
        public int HobbyId { get; set; }
    }
}
