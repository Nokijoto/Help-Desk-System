using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class PDU : Asset
    {
        public int NumberOfPorts { get; set; }            // Liczba portów
        public int MaxPowerOutput { get; set; }           // Maksymalna moc wyjściowa w W
        public bool IsManaged { get; set; }               // Czy jest zarządzany
        public string? ConnectionType { get; set; }       // Typ połączenia (3-phase, Single-phase)
    }
}
