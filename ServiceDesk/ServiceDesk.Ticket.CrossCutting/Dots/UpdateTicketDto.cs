using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.CrossCutting.Dots
{
    public class UpdateTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requester { get; set; }
    }
}
