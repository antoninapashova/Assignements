using FluentAssertions;
using FluentValidation;
using HobbyProject.Presentation.Middleware.ExceptionMiddleware.Exceptions;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace HobbyProject.Presentation.Middleware.ExceptionMiddleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception) =>exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
        
        private static string GetTitle(Exception exception) => exception switch
         {
                ApplicationException applicationException => applicationException.Message,
                _=> "Server Error"
         };

        private static Dictionary<string, string> GetErrors(Exception exception)
        {
            //Dictionary<string, string> errors = null;
            if (exception is ValidationException validationException)
            {
                if (validationException.Errors.Any())
                {
                  var errors = new Dictionary<string, string>();

                    foreach(var e in validationException.Errors)
                    {
                        errors.Add(e.PropertyName, e.ErrorMessage);
                    }
                    return errors;
                 }

            }
            return null;
        }
    }
}
