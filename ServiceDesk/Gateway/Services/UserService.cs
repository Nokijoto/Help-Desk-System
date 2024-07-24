using Gateway.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                };
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        public async Task<IdentityUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, string role)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, role);
            }
            return result;
        }

        public async Task<IdentityResult> UpdateUserRoleAsync(IdentityUser user, string newRole)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, newRole);
            }
            return result;
        }

        public async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(IdentityUser user)
        {
            return await _userManager.DeleteAsync(user);
        }
    }
}
