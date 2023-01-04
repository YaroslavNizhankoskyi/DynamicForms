using Application.Interfaces;
using Web.Services;

namespace Web.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration config)
        {
            services.AddJwtSettings(config);

            services.AddTransient<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
