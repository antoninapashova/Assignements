using MediatR;

namespace Application.Hobby.Commands.Delete
{
    public class DeleteHobbyCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
