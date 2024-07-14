using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceDesk.User.CrossCutting.Dtos;
using System.Text;

namespace Gateway.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5000/users");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserDto>>(content);
                return View(users);
            }

            return View(new List<UserDto>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createUserDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/users", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
            return View(createUserDto);
        }
    }
}
