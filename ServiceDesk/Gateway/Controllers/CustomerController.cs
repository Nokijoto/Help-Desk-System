using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    public class CustomerController : Controller
    {
        
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
