using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class AssetDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Location { get; set; }
        public string? AssetType { get; set; }
        public string? Technician { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? InventoryNumber { get; set; }
        public string? User { get; set; }
        public DateTime PurchaseDate { get; set; }        // Data zakupu
        public decimal PurchasePrice { get; set; }        // Cena zakupu
        public string? Manufacturer { get; set; }         // Producent

        public string? Description { get; set; }           // Opis
        public string? Comment { get; set; }              // Komentarz

        public string? Discriminator { get; set; }       // Discriminator
    }
}
