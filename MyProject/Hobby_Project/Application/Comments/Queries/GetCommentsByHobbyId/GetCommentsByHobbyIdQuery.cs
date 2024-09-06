using HobbyProject.Application.Comments.Dto;
using MediatR;

namespace HobbyProject.Application.Comments.Queries.GetCommentsByHobbyId
{
    public class GetCommentsByHobbyIdQuery : IRequest<IList<CommentDto>>
    {
        public int HobbyId { get; set; }
    }
}
