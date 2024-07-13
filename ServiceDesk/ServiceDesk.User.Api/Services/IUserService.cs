using ServiceDesk.User.CrossCutting.Dtos;

namespace ServiceDesk.User.Api.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task UpdateUserAsync(Guid id, UpdateUserDto updateUserDto);
    }
}