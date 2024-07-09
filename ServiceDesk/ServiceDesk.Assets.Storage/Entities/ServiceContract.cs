using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class ServiceContract:BaseEntity
    {

        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }

        [Required]
        [MaxLength(100)]
        public string Provider { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Details { get; set; }
    }
}
