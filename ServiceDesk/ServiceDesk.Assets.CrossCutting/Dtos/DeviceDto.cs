using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.CrossCutting.Dtos
{
    public class DeviceDto : AssetDto
    {
        public string? DeviceType { get; set; }
        public bool IsPortable { get; set; }
        public string? Connectivity { get; set; }
    }
}
