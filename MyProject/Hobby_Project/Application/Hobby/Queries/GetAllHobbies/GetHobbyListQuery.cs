using Application.Hobby.Queries;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetAllUsers
{
    public class GetHobbyListQuery : IRequest<IEnumerable<HobbyDto>>
    {
    }
}
