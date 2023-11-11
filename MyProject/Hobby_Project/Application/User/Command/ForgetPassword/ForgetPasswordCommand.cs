using MediatR;

namespace HobbyProject.Application.User.Command.ForgetPassword
{
    public class ForgetPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
}
