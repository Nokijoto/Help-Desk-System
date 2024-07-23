using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos.AssetsCreateDto
{
    public class CreateComputerDto : CreateAssetDto
    {
       
        public string OperatingSystem { get; set; }
        public int RamSize { get; set; }
        public int StorageSize { get; set; }
        public string Processor { get; set; }
        public bool HasGraphicsCard { get; set; }
        public string GraphicsCardModel { get; set; }
    }
}
