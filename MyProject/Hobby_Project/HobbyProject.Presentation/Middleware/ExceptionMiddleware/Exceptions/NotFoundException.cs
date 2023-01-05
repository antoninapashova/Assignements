namespace HobbyProject.Presentation.Middleware.ExceptionMiddleware.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
