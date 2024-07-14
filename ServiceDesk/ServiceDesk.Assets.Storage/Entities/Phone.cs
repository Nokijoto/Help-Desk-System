using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Phone : Asset
    {
        public string? PhoneNumber { get; set; }          // Numer telefonu
        public string? Carrier { get; set; }              // Operator
        public string? OperatingSystem { get; set; }      // System operacyjny
        public int StorageSize { get; set; }              // Pamięć wewnętrzna w GB
        public bool IsSmartphone { get; set; }            // Czy jest smartfonem
        public string? IMEI { get; set; }                 // Numer IMEI

    }
}
