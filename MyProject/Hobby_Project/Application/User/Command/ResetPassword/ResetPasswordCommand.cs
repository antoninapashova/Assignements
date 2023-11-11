using MediatR;

namespace HobbyProject.Application.User.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string EmailToken { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
