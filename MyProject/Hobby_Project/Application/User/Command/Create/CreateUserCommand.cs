using MediatR;

namespace HobbyProject.Application.User.Command.Create
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
