using Gateway.Models;

namespace Gateway.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task RegisterAsync(RegisterModel registerModel);
    }
}