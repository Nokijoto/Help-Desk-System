using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class PhoneDto : AssetDto
    {
        [DisplayName("Numer Telefonu")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Operator")]
    public string? Carrier { get; set; }

    [DisplayName("System Operacyjny")]
    public string? OperatingSystem { get; set; }

    [DisplayName("Pojemność Pamięci")]
    public int StorageSize { get; set; }

    [DisplayName("Smartfon")]
    public bool IsSmartphone { get; set; }

    [DisplayName("IMEI")]
    public string? IMEI { get; set; }
    }
}
