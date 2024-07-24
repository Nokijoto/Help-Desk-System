using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class TicketDto
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [DisplayName("Status")]
        public string StatusName { get; set; }
        [DisplayName("Priorytet")]
        public string PriorityName { get; set; }
        [DisplayName("Zgłaszający")]
        public string Requester { get; set; }
        [DisplayName("Przypisany do")]
        public string Assignee { get; set; }
    }
}
