namespace HobbyProject.Presentation.Middleware
{
    public static class UserConfigurationExtension
    {
        public static IApplicationBuilder UseUserConfiguration(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UserConfigurationMiddleware>();
        }
    }
}
