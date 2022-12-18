using Microsoft.Extensions.Primitives;

namespace HobbyProject.Presentation.Middleware
{
    public class UserConfigurationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserConfigurationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserConfiguration userConfiguration)
        {
            if (httpContext.Request.Headers.TryGetValue("Username", out StringValues username))
            {
                userConfiguration.Username = username.SingleOrDefault();
            }
            else
            {
                //Here you can throw exception to force client to send the header
            }

            userConfiguration.InvokedDateTime = DateTime.UtcNow;

            await _next.Invoke(httpContext);
        }
    }
}
