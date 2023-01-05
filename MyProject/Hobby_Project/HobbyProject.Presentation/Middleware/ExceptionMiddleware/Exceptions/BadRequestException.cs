namespace HobbyProject.Presentation.Middleware.ExceptionMiddleware.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {
        }

        public BadRequestException(string? message) : base(message)
        {
        }
    }
}
