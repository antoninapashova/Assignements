using HobbyProject.Domain.Entity;
using System.Security.Claims;

namespace HobbyProject.Application.Helpers
{
    public interface ITokenManager
    {
        string CreateRefreshToken();
        string CreateJwtToken(UserEntity user);
        ClaimsPrincipal GetPrincipleFromExpiredToken(string token);
    }
}