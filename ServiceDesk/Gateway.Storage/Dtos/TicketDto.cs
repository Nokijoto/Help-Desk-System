using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class TicketDto
    {
        public string Title { get; set; }
        public string StatusName { get; set; }
        public string PriorityName { get; set; }
        public string Requester { get; set; }
        public string Assignee { get; set; }
    }
}
