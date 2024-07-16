using Gateway.Models;
using Gateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            
        }

        [HttpGet]
        public IActionResult LoginView()
        {
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }
        [HttpGet]
        public IActionResult RegisterView()
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
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var token = await _authService.LoginAsync(model);
                HttpContext.Session.SetString("JWToken", token);

                var user = await _authService.GetCurrentUserAsync(token);

                if (user != null)
                {
                    if (await _authService.IsInRoleAsync(user, "Customer"))
                    {
                        return RedirectToAction("CustomerIndex", "User");
                    }
                    else if (await _authService.IsInRoleAsync(user, "Administrator"))
                    {
                        return RedirectToAction("AdministratorIndex", "User");
                    }
                    else if (await _authService.IsInRoleAsync(user, "Serviceman"))
                    {
                        return RedirectToAction("ServicemanIndex", "User");
                    }
                }

                return Unauthorized();
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
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Index", "Home");
        }
    }
}

