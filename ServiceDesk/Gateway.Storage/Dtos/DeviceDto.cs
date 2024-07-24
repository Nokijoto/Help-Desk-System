using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class DeviceDto : AssetDto
    {
        [DisplayName("Typ Urządzenia")]
    public string? DeviceType { get; set; }

    [DisplayName("Czy Przenośny")]
    public bool IsPortable { get; set; }

    [DisplayName("Łączność")]
    public string? Connectivity { get; set; }
    }
}
