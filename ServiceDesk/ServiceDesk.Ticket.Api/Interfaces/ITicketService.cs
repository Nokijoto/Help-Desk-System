using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTickets();
        Task<TicketDto> GetTicket(Guid id);
        Task CreateTicket(TicketDto ticketDto);
        Task DeleteTicket(Guid id);
        Task UpdateTicket(Guid id, TicketDto ticketDto);
    }
}
