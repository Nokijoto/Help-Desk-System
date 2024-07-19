using EmailNotification.Models;
using ServiceDesk.Ticket.Api.Services;
using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTickets();
        Task<DetailsTicketDto> GetTicket(Guid id);
        Task CreateTicket(CreateTicketDto ticketDto);
        Task DeleteTicket(Guid id);
        Task UpdateTicket(Guid id, UpdateTicketDto ticketDto);
        Task ChangeTicketStatus(Guid id, StatusDto statusName);
        Task ChangeTicketPriority(Guid id, PriorityDto priorityName);
        Task ChangeTicketAssignee(Guid id, UpdateAssigneeDto assignee);
    }
}
