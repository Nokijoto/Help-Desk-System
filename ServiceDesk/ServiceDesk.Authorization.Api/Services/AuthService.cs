using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ServiceDesk.Authorization.CrossCutting.Dtos;
using ServiceDesk.Authorization.Storage.Entities;
using ServiceDesk.User.Storage.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceDesk.Authorization.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User.Storage.Entities.User> _userManager;
        private readonly SignInManager<User.Storage.Entities.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User.Storage.Entities.User> _passwordHasher;

        public AuthService(UserManager<User.Storage.Entities.User> userManager, SignInManager<User.Storage.Entities.User> signInManager, IMapper mapper, IConfiguration configuration, IPasswordHasher<User.Storage.Entities.User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User.Storage.Entities.User>(registerDto);
            user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new Exception("Invalid login attempt");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (result != PasswordVerificationResult.Success)
            {
                throw new Exception("Invalid login attempt");
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User.Storage.Entities.User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
