using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.Storage.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }=DateTime.Now;


        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
