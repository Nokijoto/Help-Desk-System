using Gateway.Factories;
using Gateway.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public class TicketController : Controller
    {
        private readonly IAssetClientFactory _assetClientFactory;
        private readonly String mailUrl = "http://localhost:5183/Mail";
        private readonly String serviceUrl = "https://localhost:7061/api/Ticket";
        public TicketController(IAssetClientFactory assetClientFactory)
        {
            _assetClientFactory = assetClientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Client = _assetClientFactory.CreateClient<TicketDto>($"{serviceUrl}");
            var items = await Client.GetAllAsyncTicket();
            return View("../Assets/GenericView", items);
            
        }
        [HttpPost]
        public async Task CreateTicket()
        {
            var client = _assetClientFactory.CreateClient<MailDto>($"{serviceUrl}/ticketCreated");
           var mailDto =new MailDto
           {
                EmailToId = "mailDto.EmailToId",
                EmailToName = "mailDto.EmailToName",
                EmailSubject = "mailDto.EmailSubject",
                EmailBody = "mailDto.EmailBody"
           };
            await client.AddAsync(mailDto);
        }
    }
}
