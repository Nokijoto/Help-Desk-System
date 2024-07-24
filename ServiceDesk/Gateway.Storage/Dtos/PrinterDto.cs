using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class PrinterDto : AssetDto
    {
       [DisplayName("Kolorowa")]
    public bool IsColor { get; set; }

    [DisplayName("Szybkość Druku")]
    public int PrintSpeed { get; set; }

    [DisplayName("Typ Drukarki")]
    public string? PrinterType { get; set; }

    [DisplayName("Z Skanerem")]
    public bool HasScanner { get; set; }

    [DisplayName("Pojemność Papieru")]
    public int PaperCapacity { get; set; }
    }
}
