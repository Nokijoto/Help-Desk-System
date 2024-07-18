using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
