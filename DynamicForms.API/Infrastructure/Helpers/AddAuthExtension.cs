using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Data.Helpers
{
    internal static class AddAuthExtension
    {
        private const string JWT_ISSUER_CONFIG = "Jwt:Issuer";
        private const string JWT_KEY_CONFIG = "Jwt:Key";
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();

            services.AddAuthentication(
                option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration[JWT_ISSUER_CONFIG],
                            ValidAudience = configuration[JWT_ISSUER_CONFIG],
                            IssuerSigningKey = new
                            SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[JWT_KEY_CONFIG]))
                        };
                    });

            return services;
        }
    }
}
