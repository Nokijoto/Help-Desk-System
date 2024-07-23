using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreateDeviceDto : CreateAssetDto
    {
        public string? DeviceType { get; set; }
        public bool IsPortable { get; set; }
        public string? Connectivity { get; set; }
    }
}
