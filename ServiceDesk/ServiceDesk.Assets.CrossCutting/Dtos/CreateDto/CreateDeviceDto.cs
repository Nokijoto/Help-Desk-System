using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.CrossCutting.Dtos.CreateDto
{
    public class CreateDeviceDto : CreateAssetDto
    {
        public string? DeviceType { get; set; }
        public bool IsPortable { get; set; }
        public string? Connectivity { get; set; }
    }
}
