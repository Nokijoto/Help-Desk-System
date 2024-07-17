using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.CrossCutting.Dots
{
    public class ElementDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid AssertId { get; set; }
    }
}
