namespace HobbyProject.Presentation.Middleware
{
    public class UserConfiguration : IUserConfiguration
    {
        public string Username { get; set; }

        public DateTime InvokedDateTime { get; set; }
    }
}
