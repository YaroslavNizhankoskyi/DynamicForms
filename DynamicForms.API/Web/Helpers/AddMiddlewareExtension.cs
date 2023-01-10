using Web.Middleware;

namespace Web.Helpers
{
    public static class AddMiddlewareExtension
    {
        public static IServiceCollection AddMidlleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
