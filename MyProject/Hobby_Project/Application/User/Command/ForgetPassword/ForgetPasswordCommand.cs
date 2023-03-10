using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.ForgetPassword
{
    public class ForgetPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
}
