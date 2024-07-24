using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class RackDto : AssetDto
    {
          [DisplayName("Liczba Jednostek")]
    public int NumberOfUnits { get; set; }

    [DisplayName("Maksymalna Waga")]
    public int MaxWeight { get; set; }

    [DisplayName("Wentylowany")]
    public bool IsVentilated { get; set; }

    [DisplayName("Pojemność Mocy")]
    public int PowerCapacity { get; set; }
    }
}
