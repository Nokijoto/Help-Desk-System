using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class MonitorDto : AssetDto
    {
       
    [DisplayName("Rozmiar Ekranu")]
    public int ScreenSize { get; set; }

    [DisplayName("Rozdzielczość")]
    public string? Resolution { get; set; }

    [DisplayName("Typ Panelu")]
    public string? PanelType { get; set; }

    [DisplayName("Czy Zakrzywiony")]
    public bool IsCurved { get; set; }

    [DisplayName("Częstotliwość Odświeżania")]
    public int RefreshRate { get; set; }
    }
}
