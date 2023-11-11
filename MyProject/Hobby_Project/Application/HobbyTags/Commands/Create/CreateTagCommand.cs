using HobbyProject.Domain.Entity;
using MediatR;

namespace Application.HobbyTags.Commands.Create
{
    public class CreateTagCommand : IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
