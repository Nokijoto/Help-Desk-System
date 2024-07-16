using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Gateway.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = { "Administrator", "Customer", "Serviceman" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var admin = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
                await CreateUserAsync(userManager, admin, "Administrator", "AdminPassword123!");

                var customer = new IdentityUser { UserName = "customer@example.com", Email = "customer@example.com" };
                await CreateUserAsync(userManager, customer, "Customer", "CustomerPassword123!");

                var serviceman = new IdentityUser { UserName = "serviceman@example.com", Email = "serviceman@example.com" };
                await CreateUserAsync(userManager, serviceman, "Serviceman", "ServicemanPassword123!");
            }
        }

        private static async Task CreateUserAsync(UserManager<IdentityUser> userManager, IdentityUser user, string role, string password)
        {
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
