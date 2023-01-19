using Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserListQuery : IRequest<IEnumerable<UserDto>>
    {
        
    }
}
