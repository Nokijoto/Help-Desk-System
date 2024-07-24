using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class SimcardDto : AssetDto
    {
        [DisplayName("Numer Telefonu")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Operator")]
    public string? Carrier { get; set; }

    [DisplayName("Typ Planu")]
    public string? PlanType { get; set; }

    [DisplayName("Data Aktywacji")]
    public DateTime ActivationDate { get; set; }

    [DisplayName("Data Wygaszenia")]
    public DateTime ExpiryDate { get; set; }
    }
}
