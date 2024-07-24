using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Computer : Asset
    {
        public string? OperatingSystem { get; set; }
        public int RAMSize { get; set; }                  // w GB
        public int StorageSize { get; set; }              // w GB
        public string? Processor { get; set; }            // Procesor
        public bool HasGraphicsCard { get; set; }         // Czy posiada kartę graficzną
        public string? GraphicsCardModel { get; set; }    // Model karty graficznej
    }
}
