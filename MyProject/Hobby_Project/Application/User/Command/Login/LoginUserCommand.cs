using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.Login
{
    public class LoginUserCommand : IRequest<UserEntity>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
