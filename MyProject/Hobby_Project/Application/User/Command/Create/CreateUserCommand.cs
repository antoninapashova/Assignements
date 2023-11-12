using MediatR;
using System.Text.Json.Serialization;

namespace HobbyProject.Application.User.Command.Create
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
