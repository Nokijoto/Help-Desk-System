using AutoMapper;
using EmailNotification.Models;
using EmailNotification.Services;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;
using System.ComponentModel;

namespace ServiceDesk.Ticket.Api.Services
{
    public enum StatusTicket
    {
        New,
        InProgress,
        Resolved,
    }
    public enum PriorityTicket
    {
        Low,
        Medium,
        High,
        Urgent
    }

    public class TicketService:ITicketService
    {
        private readonly TicketDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public TicketService(TicketDbContext dbContext, IMapper mapper, IMailService mailService)
        {
            _dbContext = dbContext;
            _mapper=mapper;
            _mailService = mailService;
        }
        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            var tickets = await _dbContext.Tickets.Include(x=>x.Status).Include(x=>x.Priority).ToListAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }
        public async Task<DetailsTicketDto> GetTicket(Guid id)
        {
            var ticket = await _dbContext.Tickets.Include(r=>r.Tasks).Include(r=>r.Notes).FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<DetailsTicketDto>(ticket);
        }

        public async Task CreateTicket(CreateTicketDto ticketDto)
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
        public async Task UpdateTicket(Guid id, UpdateTicketDto ticketDto)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket is null) {
                throw new Exception("Ticket not found");
            }
            _mapper.Map(ticketDto, ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeTicketStatus(Guid id, StatusTicket statusName, MailData mailData)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket is null) {
                throw new Exception("Ticket not found");
            }
            //if (statusName == StatusTicket.Resolved)
            //{
            //    var template="ticketClosed";
            //    await _mailService.SendMailAsync(mailData, template);
            //}
            
            var status= await _dbContext.Statuses.FirstOrDefaultAsync(s=>s.Name==statusName.ToString());
            if (status is null)
            {
                throw new Exception("Status not found");
            }
            ticket.StatusId = status.Id;

            _dbContext.Tickets.Update(ticket);

            await _dbContext.SaveChangesAsync();
        } 

        public async Task ChangeTicketPriority(Guid id, PriorityTicket priorityName)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket is null) {
                throw new Exception("Ticket not found");
            }
            var priority= await _dbContext.Priorities.FirstOrDefaultAsync(s=>s.Name==priorityName.ToString());
            if (priority is null)
            {
                throw new Exception("Priority not found");
            }
            ticket.PriorityId = priority.Id;

            _dbContext.Tickets.Update(ticket);

            await _dbContext.SaveChangesAsync();
        }
        public async Task ChangeTicketAssignee(Guid id, string assignee)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket is null)
            {
                throw new Exception("Ticket not found");
            }

            ticket.Assignee = assignee;

            _dbContext.Tickets.Update(ticket);

            await _dbContext.SaveChangesAsync();
        }
    }
}
