namespace HobbyProject.Presentation.Middleware
{
    public interface IUserConfiguration
    {
        string Username { get; set; }

        DateTime InvokedDateTime { get; set; }
    }
}
