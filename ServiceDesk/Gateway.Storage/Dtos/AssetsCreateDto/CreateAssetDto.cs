using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{ 
    public class CreateAssetDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string AssetType { get; set; }
        public string Technician { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Discriminator { get; set; }
    }
}
