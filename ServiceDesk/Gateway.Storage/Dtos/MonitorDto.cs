using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Storage.Dtos
{
    public class MonitorDto : AssetDto
    {
        public int ScreenSize { get; set; }
        public string? Resolution { get; set; }
        public string? PanelType { get; set; }
        public bool IsCurved { get; set; }
        public int RefreshRate { get; set; }
    }
}
