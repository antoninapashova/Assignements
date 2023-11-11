using MediatR;

namespace Application.Hobby.Commands.Edit
{
    public class UpdateHobbyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
