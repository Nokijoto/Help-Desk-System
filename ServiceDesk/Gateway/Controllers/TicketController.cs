using Gateway.Factories;
using Gateway.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public enum StatusTicket
    {
        New,
        InProgress,
        Resolved,
    }
    public class TicketController : Controller
    {
        private readonly IApiClientFactory _ClientFactory;
        private readonly String mailUrl = "http://localhost:5183/Mail";
        private readonly String serviceUrl = "https://localhost:7061/api/Ticket";
        public TicketController(IApiClientFactory assetClientFactory)
        {
            _ClientFactory = assetClientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Client = _ClientFactory.CreateClient<TicketDto>($"{serviceUrl}");
            var items = await Client.GetAllAsyncTicket();
            return View( items);
            
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<DetailsTicketDto>($"{serviceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<UpdateTicketDto>($"{serviceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] Guid id, UpdateTicketDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<UpdateTicketDto>($"{serviceUrl}");
            await Client.UpdateAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<CreateTicketDto>($"{serviceUrl}");
            await Client.AddAsync(ticketDto);
            //await CreateTicket();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<TicketDto>($"{serviceUrl}");
            await Client.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<StatusTicketDto>($"{serviceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(Guid id, StatusTicketDto statusName)
        {
            var Client = _ClientFactory.CreateClient<StatusTicketDto>($"{serviceUrl}");
            await Client.UpdateStatusAsync(id, statusName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAssignee([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<UpdateAssignee>($"{serviceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssignee([FromRoute] Guid id, UpdateAssignee ticketDto)
        {
            var Client = _ClientFactory.CreateClient<UpdateAssignee>($"{serviceUrl}");
            await Client.UpdateAssigneeAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePriority([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<PriorityTicketDto>($"{serviceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePriority([FromRoute] Guid id, PriorityTicketDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<PriorityTicketDto>($"{serviceUrl}");
            await Client.UpdatePriorityAsync(id, ticketDto);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task CreateTicket()
        {
            var client = _ClientFactory.CreateClient<MailDto>($"{mailUrl}/ticketCreated");
           var mailDto =new MailDto
           {
                EmailToId = "mailDto.EmailToId",
                EmailToName = "mailDto.EmailToName",
                EmailSubject = "mailDto.EmailSubject",
                EmailBody = "Zgłoszenie zostało utworzone"
           };
            await client.AddAsync(mailDto);
        }
    }
}
