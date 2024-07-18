using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class PDUDto : AssetDto
    {
          [DisplayName("Liczba Portów")]
    public int NumberOfPorts { get; set; }

    [DisplayName("Maksymalne Wyjście Mocy")]
    public int MaxPowerOutput { get; set; }

    [DisplayName("Zarządzany")]
    public bool IsManaged { get; set; }

    [DisplayName("Typ Połączenia")]
    public string? ConnectionType { get; set; }
    }
}
