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
        public DbSet<Entity.Ticket>Tickets { get; set; }
        public DbSet<Entity.Note>Notes { get; set; }
        public DbSet<Entity.Task>Tasks { get; set; }
        public DbSet<Entity.Priority> Priorities { get; set; }
        public DbSet<Entity.Status> Statuses { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }
    }
}
