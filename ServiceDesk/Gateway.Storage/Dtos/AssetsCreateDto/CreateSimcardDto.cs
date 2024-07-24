using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreateSimcardDto : CreateAssetDto
    {
        public string? PhoneNumber { get; set; }
        public string? Carrier { get; set; }
        public string? PlanType { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
