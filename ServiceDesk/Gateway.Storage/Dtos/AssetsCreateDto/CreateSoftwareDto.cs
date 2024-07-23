using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreateSoftwareDto : CreateAssetDto
    {
        public string? Version { get; set; }
        public string? LicenseKey { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public int NumberOfUsers { get; set; }
        public string? Vendor { get; set; }
    }
}
