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
        private readonly String ticketServiceUrl = "https://localhost:7061/api/Ticket";
        private readonly String noteServiceUrl = "https://localhost:7061/api/Note";
        private readonly String taskServiceUrl = "https://localhost:7061/api/Task";
        private readonly String elementServiceUrl = "https://localhost:7061/api/Element";



        public TicketController(IApiClientFactory assetClientFactory)
        {
            _ClientFactory = assetClientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Client = _ClientFactory.CreateClient<TicketDto>($"{ticketServiceUrl}");
            var items = await Client.GetAllAsyncTicket();
            return View( items);
            
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<DetailsTicketDto>($"{ticketServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<UpdateTicketDto>($"{ticketServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] Guid id, UpdateTicketDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<UpdateTicketDto>($"{ticketServiceUrl}");
            await Client.UpdateAsync(id, ticketDto);
            await UpdateTicket();
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
            var Client = _ClientFactory.CreateClient<CreateTicketDto>($"{ticketServiceUrl}");
            await Client.AddAsync(ticketDto);
            await CreateTicket();
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
            var Client = _ClientFactory.CreateClient<TicketDto>($"{ticketServiceUrl}");
            await Client.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<StatusTicketDto>($"{ticketServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(Guid id, StatusTicketDto statusName)
        {
            var Client = _ClientFactory.CreateClient<StatusTicketDto>($"{ticketServiceUrl}");
            await Client.UpdateStatusAsync(id, statusName);
            if (statusName.Name == "Resolved")
            {
                await ResolvedTicket();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAssignee([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<UpdateAssignee>($"{ticketServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssignee([FromRoute] Guid id, UpdateAssignee ticketDto)
        {
            var Client = _ClientFactory.CreateClient<UpdateAssignee>($"{ticketServiceUrl}");
            await Client.UpdateAssigneeAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePriority([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<PriorityTicketDto>($"{ticketServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePriority([FromRoute] Guid id, PriorityTicketDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<PriorityTicketDto>($"{ticketServiceUrl}");
            await Client.UpdatePriorityAsync(id, ticketDto);
            return RedirectToAction("Index");
        }
        
        // Note
      

        [HttpGet]
        public async Task<IActionResult> CreateNote()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(Guid id, NoteDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<NoteDto>($"{noteServiceUrl}");
            await Client.AddNoteAsync(id,ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditNote([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<NoteDto>($"{noteServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditNote([FromRoute] Guid id, NoteDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<NoteDto>($"{noteServiceUrl}");
            await Client.UpdateNoteAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<NoteDto>($"{noteServiceUrl}");
            await Client.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        //Task
        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(Guid id, TaskDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<TaskDto>($"{taskServiceUrl}");
            await Client.AddTaskAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditTask([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<TaskDto>($"{taskServiceUrl}");
            var item = await Client.GetByIdAsyncTicket(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask([FromRoute] Guid id, TaskDto ticketDto)
        {
            var Client = _ClientFactory.CreateClient<TaskDto>($"{taskServiceUrl}");
            await Client.UpdateTaskAsync(id, ticketDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<TaskDto>($"{taskServiceUrl}");
            await Client.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        //Element

        [HttpGet]
        public async Task<IActionResult> GetElements([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<AssetDto>($"{elementServiceUrl}");
            var item = await Client.GetByIdElementAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> CreateElements([FromRoute] Guid ticketId)
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateElements([FromRoute] Guid ticketId, ElementDto model)
        {
            var Client = _ClientFactory.CreateClient<string>($"{elementServiceUrl}");
            await Client.AddElementAsync(ticketId, model.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteElements()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteElements([FromRoute] Guid id)
        {
            var Client = _ClientFactory.CreateClient<ElementDto>($"{taskServiceUrl}");
            await Client.DeleteAsync(id);

            return RedirectToAction("Index");
        }


        //Mail wysyłanie
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

        [HttpPost]
        public async Task UpdateTicket()
        {
            var client = _ClientFactory.CreateClient<MailDto>($"{mailUrl}/ticketUpdated");
            var mailDto = new MailDto
            {
                EmailToId = "mailDto.EmailToId",
                EmailToName = "mailDto.EmailToName",
                EmailSubject = "mailDto.EmailSubject",
                EmailBody = "Zgłoszenie zostało zaktualizowane"
            };
            await client.AddAsync(mailDto);
        }
        [HttpPost]
        public async Task ResolvedTicket()
        {
            var client = _ClientFactory.CreateClient<MailDto>($"{mailUrl}/ticketClosed");
            var mailDto = new MailDto
            {
                EmailToId = "mailDto.EmailToId",
                EmailToName = "mailDto.EmailToName",
                EmailSubject = "mailDto.EmailSubject",
                EmailBody = "Zgłoszenie zostało rozwiązane"
            };
            await client.AddAsync(mailDto);
        }
    }
}
