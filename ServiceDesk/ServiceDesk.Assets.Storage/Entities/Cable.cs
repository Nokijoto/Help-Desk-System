using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Cable : Asset
    {
        public string? CableType { get; set; }            // Typ kabla (Ethernet, HDMI, etc.)
        public int Length { get; set; }                   // Długość w metrach
        public string? ConnectorType { get; set; }        // Typ złącza (RJ45, USB-C, etc.)
        public bool IsShielded { get; set; }              // Czy jest ekranowany
    }
}
