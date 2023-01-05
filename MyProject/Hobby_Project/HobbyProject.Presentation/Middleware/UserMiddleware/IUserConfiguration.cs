namespace HobbyProject.Presentation.Middleware.UserMiddleware
{
    public interface IUserConfiguration
    {
        string Username { get; set; }

        DateTime InvokedDateTime { get; set; }
    }
}
