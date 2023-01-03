using Infrastructure.Data.Domain;
using Infrastructure.Data.Helpers;
using Infrastructure.Data.Identity;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DomainDbContext>(
                            options => options.UseSqlServer(
                                configuration["ConnectionStrings:DomainDB"],
                                m => m.MigrationsAssembly("Infrastructure")));

            services.AddDbContext<AppIdentityDbContext>(
                            options => options.UseSqlServer(
                                configuration["ConnectionStrings:DomainDb"],
                                m => m.MigrationsAssembly("Infrastructure")));

            services.AddIdentityServices();

            services.AddAuth(configuration);

            return services;
        }
    }
}
