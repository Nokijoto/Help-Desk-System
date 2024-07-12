using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api.Services
{
    public class TicketService:ITicketService
    {
        private readonly TicketDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketService(TicketDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper=mapper;
        }
        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            var tickets = await _dbContext.Tickets.ToListAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }
        public async Task<TicketDto> GetTicket(Guid id)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task CreateTicket(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Storage.Entities.Ticket>(ticketDto);
            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteTicket(Guid id) {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket != null) {
                _dbContext.Tickets.Remove(ticket);
               await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateTicket(Guid id, TicketDto ticketDto)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket is null) {
                throw new Exception("Ticket not found");
            }
            _mapper.Map(ticketDto, ticket);
            await _dbContext.SaveChangesAsync();
           
        }
    }
}
