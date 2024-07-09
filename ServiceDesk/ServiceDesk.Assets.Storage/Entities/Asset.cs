using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Asset : BaseEntity
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; } // AssetType ID
        public string SerialNumber { get; set; }
        public Guid LocationId { get; set; } // Location ID
        public AssetStatus Status { get; set; }
        public Guid? AssignedTo { get; set; } // User ID
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
    }
    public enum AssetStatus
    {
        Active,
        Inactive,
        Maintenance,
        Decommissioned
    }
}
