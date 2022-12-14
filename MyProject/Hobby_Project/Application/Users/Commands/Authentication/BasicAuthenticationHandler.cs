using Application.Repositories;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using IAuthenticationHandler = Microsoft.AspNetCore.Authentication.IAuthenticationHandler;

namespace HobbyProject.Application.Users.Commands.Authentication
{
    public class BasicAuthenticationHandler
        //: IAuthenticationHandler
    {
        /*
        private readonly IUnitOfWork _unitOfWork;

        public BasicAuthenticationHandler(
            IOptionsMonitor options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, 
            IUnitOfWork unitOfWork) : base(options, logger, encoder, clock)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (authorizationHeader != null && authorizationHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authorizationHeader.Substring("Basic ".Length).Trim();
                var credentialsAsEncodedString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialsAsEncodedString.Split(':');
                if (await _unitOfWork.UserRepository.Authenticate(credentials[0], credentials[1]))
                {
                    var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }
            }
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            throw new NotImplementedException();
        }
        */
    }
}
