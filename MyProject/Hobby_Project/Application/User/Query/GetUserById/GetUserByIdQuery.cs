using HobbyProject.Application.User.Dto;
using MediatR;

namespace HobbyProject.Application.User.Query.GetById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
