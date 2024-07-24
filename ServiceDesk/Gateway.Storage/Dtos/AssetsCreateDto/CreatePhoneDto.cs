using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreatePhoneDto : CreateAssetDto
    {
        public string? PhoneNumber { get; set; }
        public string? Carrier { get; set; }
        public string? OperatingSystem { get; set; }
        public int StorageSize { get; set; }
        public bool IsSmartphone { get; set; }
        public string? IMEI { get; set; }
    }
}
