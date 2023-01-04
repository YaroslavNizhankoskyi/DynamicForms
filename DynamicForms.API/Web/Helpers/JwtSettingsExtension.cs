using Infrastructure.Helpers.Models;

namespace Web.Helpers
{
    public static class JwtSettingsExtension
    {
        private const string SETTINGS_PATH = "Jwt";
        public static IServiceCollection AddJwtSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(SETTINGS_PATH));

            return services;
        }
    }
}
