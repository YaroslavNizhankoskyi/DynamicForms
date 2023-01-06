using Application.Interfaces;
using Infrastructure.Data.Domain;
using Infrastructure.Data.Helpers;
using Infrastructure.Data.Identity;
using Infrastructure.Helpers;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        private const string MIGRATION_ASSEMBLY = "Infrastructure";
        private const string DB_CONNECTION = "ConnectionStrings:DomainDB";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DomainDbContext>(
                            options => options.UseSqlServer(
                                configuration[DB_CONNECTION],
                                m => m.MigrationsAssembly(MIGRATION_ASSEMBLY)));

            services.AddDbContext<AppIdentityDbContext>(
                            options => options.UseSqlServer(
                                configuration[DB_CONNECTION],
                                m => m.MigrationsAssembly(MIGRATION_ASSEMBLY)));

            services.AddIdentityServices();

            services.AddAuth(configuration);

            services.AddScoped<IIdenityAuthService, IdentityAuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IDomainDbContext>(provider => provider.GetService<DomainDbContext>());

            return services;
        }
    }
}
