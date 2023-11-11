using Application.Hobby.Queries;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetHobbyById
{
    public class GetHobbyByIdQuery : IRequest<HobbyDto>
    {
       public int Id { get; set; }
    }
}
