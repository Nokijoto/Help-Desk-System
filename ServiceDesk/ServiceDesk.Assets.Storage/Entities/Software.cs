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
    public class Software:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Version { get; set; }

        [MaxLength(100)]
        public string LicenseKey { get; set; }

        [ForeignKey("Asset")]
        public Guid InstalledOn { get; set; }
        public Asset Asset { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
