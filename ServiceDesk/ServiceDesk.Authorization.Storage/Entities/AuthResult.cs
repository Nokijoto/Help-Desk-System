using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Authorization.Storage.Entities
{
    public class AuthResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
