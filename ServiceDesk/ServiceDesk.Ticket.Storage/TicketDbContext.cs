using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.Storage
{
    public class TicketDbContext: DbContext
    {
        public DbSet<Entities.Ticket>Tickets { get; set; }
        public DbSet<Entities.Note>Notes { get; set; }
        public DbSet<Entities.Task>Tasks { get; set; }
        public DbSet<Entities.Priority> Priorities { get; set; }
        public DbSet<Entities.Status> Statuses { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }
    }
}
