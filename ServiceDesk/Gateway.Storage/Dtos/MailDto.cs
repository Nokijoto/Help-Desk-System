using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class MailDto
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
