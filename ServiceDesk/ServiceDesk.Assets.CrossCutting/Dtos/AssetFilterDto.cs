using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.CrossCutting.Dtos
{
    public class AssetFilterDto
    {
        public Dictionary<string, object> Filters { get; set; } = new Dictionary<string, object>();
    }
}
