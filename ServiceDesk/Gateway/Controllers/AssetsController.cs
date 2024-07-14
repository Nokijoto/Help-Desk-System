using CrudBase;
using Gateway.Clients;
using Gateway.Enums;
using Gateway.Factories;
using Gateway.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetClientFactory _assetClientFactory;
        private readonly String serviceUrl = "http://localhost:5256/api/";
        public AssetsController(IAssetClientFactory assetClientFactory)
        {
            _assetClientFactory = assetClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Computers()
        {
            var computerClient = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
            var computers = await computerClient.GetAllAsync();
            return View("GenericView", computers);
         
        }

        [HttpGet]
        public async Task<IActionResult> Cables()
        {

            var cableClient = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
            var cables = await cableClient.GetAllAsync();
            return View("GenericView", cables);

        }

        [HttpGet]
        public async Task<IActionResult> Details(string type, Guid id)
        {
            var item = await GetDetailsAsync(type, id);
            if (item == null)
            {
                return NotFound();
            }
            return View("GenericDetails", item);
        }

        private async Task<dynamic> GetDetailsAsync(string type, Guid id)
        {
            switch (type.ToLower())
            {
                case "computer":
                    var computerClient = _assetClientFactory.CreateClient<ComputerDto>($"{serviceUrl}Computer");
                    return await computerClient.GetByIdAsync(id);
                case "cable":
                    var cableClient = _assetClientFactory.CreateClient<CableDto>($"{serviceUrl}Cable");
                    return await cableClient.GetByIdAsync(id);
                default:
                    return null;
            }
        }

    }
}
