using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Gateway.Storage.Dtos
{
    public class SoftwareDto : AssetDto
    {
          [DisplayName("Wersja")]
    public string? Version { get; set; }

    [DisplayName("Klucz Licencyjny")]
    public string? LicenseKey { get; set; }

    [DisplayName("Data Wygaszenia Licencji")]
    public DateTime LicenseExpiryDate { get; set; }

    [DisplayName("Liczba Użytkowników")]
    public int NumberOfUsers { get; set; }

    [DisplayName("Dostawca")]
    public string? Vendor { get; set; }
    }
}
