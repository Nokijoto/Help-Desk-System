using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerIndex()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdministratorIndex()
        {
            return View();
        }

        [Authorize(Roles = "Serviceman")]
        public IActionResult ServicemanIndex()
        {
            return View();
        }
    }
}
