using Application.Hobby.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Hobby.Queries.GetHobbiesByUsername
{
    public class GetHobbiesByUsernameQuery : IRequest<IEnumerable<HobbyDto>>
    {
        public string Username { get; set; }
    }
}
