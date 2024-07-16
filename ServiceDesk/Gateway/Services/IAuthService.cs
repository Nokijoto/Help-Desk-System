using Gateway.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
        Task<IdentityUser> GetCurrentUserAsync(string token);
        Task<bool> IsInRoleAsync(IdentityUser user, string role);
        Task<IdentityResult> RegisterAsync(RegisterModel registerModel);

    }
}