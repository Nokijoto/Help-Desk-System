using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.User.CrossCutting.Dtos;
using ServiceDesk.User.Storage;

namespace ServiceDesk.User.Api.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Storage.Entities.User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Storage.Entities.User> _passwordHasher;

        public UserService(UserManager<Storage.Entities.User> userManager, IMapper mapper, IPasswordHasher<Storage.Entities.User> passwordHasher)
        {
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<Storage.Entities.User>(createUserDto);
            user.PasswordHash = _passwordHasher.HashPassword(user, createUserDto.Password);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var users = _userManager.Users.ToList(); 

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(updateUserDto, user);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
