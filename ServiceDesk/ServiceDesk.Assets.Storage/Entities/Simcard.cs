using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Simcard : Asset
    {
        public string? PhoneNumber { get; set; }          // Numer telefonu
        public string? Carrier { get; set; }              // Operator
        public string? PlanType { get; set; }             // Typ planu (Prepaid, Postpaid)
        public DateTime ActivationDate { get; set; }      // Data aktywacji
        public DateTime ExpiryDate { get; set; }          // Data wygaśnięcia
    }
}
