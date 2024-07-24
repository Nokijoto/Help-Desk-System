using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreatePDUDto : CreateAssetDto
    {
        public int NumberOfPorts { get; set; }
        public int MaxPowerOutput { get; set; }
        public bool IsManaged { get; set; }
        public string? ConnectionType { get; set; }
    }

}
