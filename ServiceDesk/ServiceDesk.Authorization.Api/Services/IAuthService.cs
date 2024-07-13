using ServiceDesk.Authorization.CrossCutting.Dtos;
using ServiceDesk.Authorization.Storage.Entities;

namespace ServiceDesk.Authorization.Api.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}