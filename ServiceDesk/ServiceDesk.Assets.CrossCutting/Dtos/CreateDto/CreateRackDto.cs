﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.CrossCutting.Dtos.CreateDto
{
    public class CreateRackDto : CreateAssetDto
    {
        public int NumberOfUnits { get; set; }
        public int MaxWeight { get; set; }
        public bool IsVentilated { get; set; }
        public int PowerCapacity { get; set; }
    }
}
