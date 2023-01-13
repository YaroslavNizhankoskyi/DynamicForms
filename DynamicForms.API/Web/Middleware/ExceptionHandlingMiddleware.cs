using Application.Helpers.Exceptions.Base;
using FluentValidation;
using System.Text.Json;

namespace Web.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static async Task HandleException(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCodes(exception);

            var response = new
            {
                title = "Server Error",
                status = statusCode,
                detail = exception.Message,
            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCodes(Exception exc)
        {
            if (exc is AuthorizationException
                || exc is AuthenticationException)
            {
                return StatusCodes.Status401Unauthorized;
            }
            else if (exc is ForbiddenActionException)
            {
                return StatusCodes.Status403Forbidden;
            }
            else if (exc is NullReferenceException)
            {
                return StatusCodes.Status404NotFound;
            }
            else if (exc is ValidationException)
            {
                return StatusCodes.Status400BadRequest;
            }

            return StatusCodes.Status500InternalServerError;
        }
    }
}
