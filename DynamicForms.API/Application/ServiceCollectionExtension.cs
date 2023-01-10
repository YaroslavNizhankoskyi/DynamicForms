using Application.Calls.Auth.Login;
using Application.Helpers.Pipeline;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;

namespace Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IHostBuilder hostBuilder)
        {
            services.AddMediatR(typeof(LoginCommand).Assembly);
            services.AddValidatorsFromAssembly(Assembly.Load("Application"));
            services.AddAutoMapper(x => x.AddMaps(Assembly.Load("Application")));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            hostBuilder.UseSerilog((ctx, lc) =>
                lc.WriteTo.Console());

            return services;
        }
    }
}
