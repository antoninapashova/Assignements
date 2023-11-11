namespace HobbyProject.Application.Helpers
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);
    }
}
