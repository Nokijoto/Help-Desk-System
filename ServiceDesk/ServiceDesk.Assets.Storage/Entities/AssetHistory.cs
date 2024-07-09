using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class AssetHistory :BaseEntity
    {

        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }

        [Required]
        [MaxLength(100)]
        public string Event { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [MaxLength(500)]
        public string Details { get; set; }
    }
}
