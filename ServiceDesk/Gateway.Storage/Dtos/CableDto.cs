using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class CableDto : AssetDto
    {
       
       [DisplayName("Typ Kabli")]
        public string CableType { get; set; }

        [DisplayName("Długość")]
        public int Length { get; set; }

        [DisplayName("Typ Złącza")]
        public string ConnectorType { get; set; }

        [DisplayName("Czy Ekranowany")]
        public bool IsShielded { get; set; }
    }
}
