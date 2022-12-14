using Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetAllUsers
{
    public class GetUserListQuery : IRequest<IEnumerable<UserVm>>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<HobbyArticleDTO> Hobbies { get; set; }
    }
}
