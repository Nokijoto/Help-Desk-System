using Gateway.Models;

namespace Gateway.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task RegisterAsync(RegisterModel registerModel);
        Task LogoutAsync();
        Task<List<string>> GetUserRolesAsync(string email);
    }
}