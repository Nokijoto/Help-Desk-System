using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.Api.Services;
using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        
        public TicketController(ITicketService ticketService)
        {
            _ticketService=ticketService;
            
        }
        [HttpGet]
        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            return await _ticketService.GetTickets();
        }

        [HttpGet("{id}")]
        public async Task<DetailsTicketDto> GetTicket(Guid id)
        {
            return await _ticketService.GetTicket(id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketDto ticketDto)
        {
            await _ticketService.CreateTicket(ticketDto);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task DeleteTicket(Guid id)
        {
            await _ticketService.DeleteTicket(id);
        }
        [HttpPut("{id}")]
        public async Task UpdateTicket(Guid id, UpdateTicketDto ticketDto)
        {
            await _ticketService.UpdateTicket(id, ticketDto);
        }

        [HttpPut("{id}/statusName")]
        public async Task ChangeTicketStatus(Guid id, [FromQuery] StatusTicket statusName)
        {
            await _ticketService.ChangeTicketStatus(id, statusName);
        }
        [HttpPut("{id}/priorityName")]
        public async Task ChangeTicketPriority(Guid id, [FromQuery] PriorityTicket priorityName)
        {
            await _ticketService.ChangeTicketPriority(id, priorityName);
        }

    }
}
