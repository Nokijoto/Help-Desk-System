using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
