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
            var statusCode = StatusCodes.Status500InternalServerError;

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

    }
}
