using AutoMapper;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api.DefaultResolver
{
    public class DefaultPriorityResolver : IValueResolver<CreateTicketDto, Storage.Entities.Ticket, Guid>
    {
        private readonly TicketDbContext _dbContext;

        public DefaultPriorityResolver(TicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Resolve(CreateTicketDto source, Storage.Entities.Ticket destination, Guid destMember, ResolutionContext context)
        {
            var priority = _dbContext.Priorities.FirstOrDefault(p => p.Name == "Medium");
            if (priority == null)
            {
                throw new Exception("Default priority 'Medium' not found");
            }
            return priority.Id;
        }
    }
}
