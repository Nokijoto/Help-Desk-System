using Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class AssetDto : BaseDto
    {
    [DisplayName("Nazwa")]
    public string? Name { get; set; }

    [DisplayName("Status")]
    public string? Status { get; set; }

    [DisplayName("Lokalizacja")]
    public string? Location { get; set; }

    [DisplayName("Typ Aktywa")]
    public string? AssetType { get; set; }

    [DisplayName("Technik")]
    public string? Technician { get; set; }

    [DisplayName("Model")]
    public string? Model { get; set; }

    [DisplayName("Numer Seryjny")]
    public string? SerialNumber { get; set; }

    [DisplayName("Numer Inwentarzowy")]
    public string? InventoryNumber { get; set; }

    [DisplayName("Użytkownik")]
    public string? User { get; set; }

    [DisplayName("Data Zakupu")]
    public DateTime PurchaseDate { get; set; }

    [DisplayName("Cena Zakupu")]
    public decimal PurchasePrice { get; set; }

    [DisplayName("Producent")]
    public string? Manufacturer { get; set; }

    [DisplayName("Opis")]
    public string? Description { get; set; }

    [DisplayName("Komentarz")]
    public string? Comment { get; set; }

    [DisplayName("Discriminator")]
    public string? Discriminator { get; set; }
    }
}
