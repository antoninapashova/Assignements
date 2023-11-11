using HobbyProject.Application.User.Dto;
using MediatR;

namespace HobbyProject.Application.User.Command.RefreshToken
{
    public class RefreshTokenCommand: IRequest<TokenApiDto>
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
