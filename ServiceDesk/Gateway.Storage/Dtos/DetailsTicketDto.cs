using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class DetailsTicketDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public string PriorityName { get; set; }
        public string Requester { get; set; }
        public string Assignee { get; set; }

        public IEnumerable<TaskDto> Tasks { get; set; }
        public IEnumerable<NoteDto> Notes { get; set; }
    }
}
