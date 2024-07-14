using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Monitor : Asset
    {
        public int ScreenSize { get; set; }               // w calach
        public string? Resolution { get; set; }           // Rozdzielczość
        public string? PanelType { get; set; }            // Typ panela (IPS, TN, VA)
        public bool IsCurved { get; set; }                // Czy jest zakrzywiony
        public int RefreshRate { get; set; }              // Częstotliwość odświeżania w Hz
    }
}
