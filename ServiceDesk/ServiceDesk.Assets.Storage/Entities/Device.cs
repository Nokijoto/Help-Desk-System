using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Device : Asset
    {
        public string? DeviceType { get; set; }           // Typ urządzenia
        public bool IsPortable { get; set; }              // Czy urządzenie jest przenośne
        public string? Connectivity { get; set; }         // Typ połączenia (WiFi, Ethernet, etc.)
    }
}
