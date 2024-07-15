using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Gateway.Controllers
{
    public class AuthController : Controller
    {
       private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View("~/Areas/Identity/Pages/Account/Register.cshtml");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            try
            {
                await _authService.RegisterAsync(registerModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var token = await _authService.LoginAsync(loginModel);

                // Przechowywanie tokena JWT w sesji (przykład z użyciem session storage)
                _httpContextAccessor.HttpContext.Session.SetString("JWToken", token);

                // Sprawdzanie roli użytkownika
                var userRoles = await _authService.GetUserRolesAsync(loginModel.Email);

                if (userRoles.Contains("Customer"))
                {
                    // Przekierowanie do akcji "Index" w kontrolerze "Customer", zastosowanie polityki autoryzacyjnej
                    return RedirectToAction("Index", "Customer");
                }
                else if (userRoles.Contains("Administrator"))
                {
                    // Przekierowanie do akcji "Index" w kontrolerze "Admin", zastosowanie polityki autoryzacyjnej
                    return RedirectToAction("Index", "Administrator");
                }
                else if (userRoles.Contains("ServiceMan"))
                {
                    // Przekierowanie do akcji "Index" w kontrolerze "Serviceman", zastosowanie polityki autoryzacyjnej
                    return RedirectToAction("Index", "Serviceman");
                }

                // Jeśli użytkownik nie ma przypisanej żadnej roli, zwróć token JWT
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            _httpContextAccessor.HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Index", "Home");
        }
    }
}

