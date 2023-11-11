using HobbyProject.Application.HobbyTags.Queries;
using MediatR;

namespace Application.HobbyTags.Queries
{
    public class GetTagListQuery : IRequest<IEnumerable<TagDto>>
    {
        public int Id { get; set; }
    }
}
