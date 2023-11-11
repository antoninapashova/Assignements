using Application.Hobby.Queries;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetHobbiesByUsername
{
    public class GetHobbiesByUsernameQuery : IRequest<IEnumerable<HobbyDto>>
    {
        public string Username { get; set; }
    }
}
