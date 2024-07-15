using Microsoft.AspNetCore.Identity;
using ServiceDesk.User.Storage.Entities;

namespace ServiceDesk.User.Api.Services
{
    public class RoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Storage.Entities.User> _userManager;

        public RoleService(RoleManager<Role> roleManager, UserManager<Storage.Entities.User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task EnsureRolesAsync()
        {
            var roles = Enum.GetNames(typeof(Role));
            foreach (var roleName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new Role(roleName));
                }
            }
        }

        public async Task AssignRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null && await _roleManager.RoleExistsAsync(roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
