using Gateway.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, string role);
        Task<IdentityResult> DeleteUserAsync(IdentityUser user);
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<IdentityUser> GetUserByIdAsync(string userId);
        Task<IdentityResult> UpdateUserRoleAsync(IdentityUser user, string newRole);
    }
}