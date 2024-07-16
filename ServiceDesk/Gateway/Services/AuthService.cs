using AutoMapper;
using Gateway.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gateway.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                throw new Exception("Invalid login attempt");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (!result.Succeeded)
                throw new Exception("Invalid login attempt");

            var claims = await GetClaimsAsync(user);
            await _signInManager.SignInAsync(user, isPersistent: false); // Logowanie użytkownika za pomocą SignInManager

            return GenerateJwtToken(claims);
        }

        private string GenerateJwtToken(List<Claim> claims)
        {
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

        private async Task<List<Claim>> GetClaimsAsync(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityUser> GetCurrentUserAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                throw new ArgumentException("UserId claim is missing.");

            return await _userManager.FindByIdAsync(userIdClaim);
        }

        public async Task<bool> IsInRoleAsync(IdentityUser user, string role)
        {
            if (user == null)
            {
                return false;
            }

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Customer");
            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }

            return result;
        }
    }
}