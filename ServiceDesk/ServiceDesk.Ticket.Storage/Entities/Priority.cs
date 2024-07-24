using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Ticket.Storage.Entities
{
    public class Priority
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
