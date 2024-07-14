using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Software : Asset
    {

        public string? Version { get; set; }              // Wersja oprogramowania
        public string? LicenseKey { get; set; }           // Klucz licencyjny
        public DateTime LicenseExpiryDate { get; set; }   // Data wygaśnięcia licencji
        public int NumberOfUsers { get; set; }            // Liczba użytkowników licencji
        public string? Vendor { get; set; }               // Dostawca oprogramowania

    }
}
