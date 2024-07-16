using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class PrinterDto : AssetDto
    {
        public bool IsColor { get; set; }
        public int PrintSpeed { get; set; }
        public string? PrinterType { get; set; }
        public bool HasScanner { get; set; }
        public int PaperCapacity { get; set; }
    }
}
