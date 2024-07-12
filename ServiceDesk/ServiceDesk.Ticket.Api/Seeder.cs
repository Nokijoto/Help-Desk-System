using ServiceDesk.Ticket.Storage;
using ServiceDesk.Ticket.Storage.Entities;

namespace ServiceDesk.Ticket.Api
{
    public class Seeder
    {
        private readonly TicketDbContext _dbContext;
        public Seeder(TicketDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public  void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Statuses.Any())
                {
                    var statuses = GetStatuses();
                    _dbContext.Statuses.AddRange(statuses);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Priorities.Any())
                {
                    var priorities = GetPriorities();
                    _dbContext.Priorities.AddRange(priorities);
                    _dbContext.SaveChanges();
                }
            }

        }
        private IEnumerable<Status> GetStatuses()
        {
            return new List<Status>
            {
                new Status { Name="New"},
                new Status { Name="In Progress"},
                new Status { Name="Resolved"},
                new Status { Name="Closed"}
            };
        }
        private IEnumerable<Priority> GetPriorities()
        {
            return new List<Priority>
            {
                new Priority { Name="Low"},
                new Priority { Name="Medium"},
                new Priority { Name="High"},
                new Priority { Name="Urgent"}
            };
        }

    }
}
