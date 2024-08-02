using Application.Logger;
using Application.Repositories;
using HobbyProject.Application.Helpers;
using HobbyProject.Application.User.Dto;
using MediatR;

namespace HobbyProject.Application.User.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenApiDto>
    {
        private readonly ITokenManager _tokenManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public RefreshTokenCommandHandler(ITokenManager tokenManager, IUnitOfWork unitOfWork)
        {
            _tokenManager = tokenManager;
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<TokenApiDto> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var principal = _tokenManager.GetPrincipleFromExpiredToken(command.AccessToken);
                var username = principal.Identity.Name;
                var user = await _unitOfWork.UserRepository.GetByUsername(username);

                if (user == null || user.RefreshToken != command.RefreshToken || user.RefreshTokenExpiredTime <= DateTime.Now)
                    throw new NullReferenceException("Invalid request");

                var newAccessToken = _tokenManager.CreateJwtToken(user);
                var newRefreshToken = _tokenManager.CreateRefreshToken();

                user.RefreshToken = newRefreshToken;
                await _unitOfWork.Save();

                return new TokenApiDto { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
            }
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
