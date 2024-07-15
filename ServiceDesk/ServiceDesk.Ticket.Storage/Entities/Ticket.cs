using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.Storage.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; } = new Guid("CDC7622E-D4AF-43BF-0865-08DCA50CEF04");
        public Status Status { get; set; }
        public Guid PriorityId { get; set; } = new Guid("F101739C-1D29-4768-7F23-08DCA50CEF12");
        public Priority Priority { get; set; }
        public string Requester { get; set; }
        public string? Assignee { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

    }
}
