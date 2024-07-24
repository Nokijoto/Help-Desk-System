using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class CreateTicketDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requester { get; set; }
    }
}
