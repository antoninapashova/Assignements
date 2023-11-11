using MediatR;

namespace HobbyProject.Application.HobbyTags.Queries.GetTagById
{
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }
}
