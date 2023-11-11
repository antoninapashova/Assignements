using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.User.Command.Login
{
    public class LoginUserCommand : IRequest<UserEntity>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
