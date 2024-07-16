using AutoMapper;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api.DefaultResolver
{
    public class DefaultStatusResolver : IValueResolver<CreateTicketDto, Storage.Entities.Ticket, Guid>
    {
        private readonly TicketDbContext _dbContext;

        public DefaultStatusResolver(TicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Resolve(CreateTicketDto source, Storage.Entities.Ticket destination, Guid destMember, ResolutionContext context)
        {
            var status = _dbContext.Statuses.FirstOrDefault(s => s.Name == "New");
            if (status == null)
            {
                throw new Exception("Default status 'New' not found");
            }
            return status.Id;
        }
    }
}
