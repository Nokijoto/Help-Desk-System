using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class CableDto : AssetDto
    {
        public string CableType { get; set; }
        public int Length { get; set; }
        public string ConnectorType { get; set; }
        public bool IsShielded { get; set; }
    }
}
