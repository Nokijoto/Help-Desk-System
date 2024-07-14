using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Rack : Asset
    {
        public int NumberOfUnits { get; set; }            // Liczba jednostek rack (U)
        public int MaxWeight { get; set; }                // Maksymalne obciążenie w kg
        public bool IsVentilated { get; set; }            // Czy posiada wentylację
        public int PowerCapacity { get; set; }            // Pojemność zasilania w kW
    }
}
