using HobbyProject.Application.Comments.Dto;
using MediatR;

namespace HobbyProject.Application.Comments.Queries.GetCommentsByHobbyId
{
    public class GetCommentsByHobbyIdQuery : IRequest<List<CommentDto>>
    {
        public int HobbyId { get; set; }
    }
}
