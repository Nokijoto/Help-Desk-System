using Gateway.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceDesk.Authorization.CrossCutting.Dtos;
using System.Text;

namespace Gateway.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Log in";
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var loginDto = new LoginDto
            {
                Email = loginModel.Input.Email,
                Password = loginModel.Input.Password
            };

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5023/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                // Zapisz token w sesji lub w ciasteczku, aby móc go używać do autoryzacji
                HttpContext.Session.SetString("JwtToken", token);
                return RedirectToAction("Index", "Home"); // Przekierowanie po udanym zalogowaniu
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var registerDto = new RegisterDto
            {
                Email = registerModel.Input.Email,
                Password = registerModel.Input.Password
                // Możesz dodać więcej pól do mapowania, jeśli są wymagane
            };

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5023/auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home"); // Przekierowanie po udanej rejestracji
            }

            ModelState.AddModelError(string.Empty, "Failed to register user");
            return View(registerModel);
        }
    }
}
