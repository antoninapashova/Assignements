using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.User.Command.Create
{
    internal class CreateUserCommand : IRequest<UserEntity>
    {
    }
}
