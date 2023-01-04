using Application.Models;
using Infrastructure.Data.Identity;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Helpers
{
    public static class Seed
    {
        public static async Task<IServiceProvider> SeedDatabase(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<AppIdentityDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                await context.Database.MigrateAsync();

                await Seed.SeedRoles(roleManager);
                await Seed.SeedAdmin(userManager, roleManager, context);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "An error occurred during migration");
            }

            return provider;
        }

        private static async Task SeedAdmin(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            AppIdentityDbContext dbContext)
        {
            var admin = dbContext.Users.FirstOrDefault(x => x.Email == "app.admin@gmail.com");

            if (admin != null) return;

            var adminCreated = new User
            {
                Email = "app.admin@gmail.com",
                UserName = "app.admin@gmail.com"
            };

            await userManager.CreateAsync(adminCreated, "ssPassword");

            await userManager.AddToRoleAsync(adminCreated, Roles.Admin);

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole<Guid> { Name = Roles.Admin });
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole<Guid> { Name = Roles.User });
        }
    }
}
