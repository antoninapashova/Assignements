using MediatR;

namespace Application.HobbyTags.Commands.Delete
{
    public class DeleteTagCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
