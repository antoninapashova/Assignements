using HobbyProject.Application.Hobby.Dto;
using MediatR;

namespace HobbyProject.Application.Hobby.Queries.GetHobbyById
{
    public class GetHobbyByIdQuery : IRequest<HobbyDto>
    {
       public int Id { get; set; }
    }
}
