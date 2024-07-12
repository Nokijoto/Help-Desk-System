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
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }
        public string Requester { get; set; }
        public string Assignee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

    }
}
