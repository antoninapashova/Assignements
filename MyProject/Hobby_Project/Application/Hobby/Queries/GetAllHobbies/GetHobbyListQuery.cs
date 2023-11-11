using HobbyProject.Application.Hobby.Dto;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetAllUsers
{
    public class GetHobbyListQuery : IRequest<IEnumerable<HobbyDto>> { }
}
