﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSDAL
{
    public class Plate
    {
        public Guid ID { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string State { get; set; }
        public string PlateLot { get; set; }
        public string PrintNumber { get; set; }
        public string PlateMaterial { get; set; }
        public string Dimension { get; set; }
        public string Supplier { get; set; }
        public string UseCount { get; set; }
        public string Hardness { get; set; }
        public string LastWeldMaterial { get; set; }
        public string Weight { get; set; }
        public string Appearance { get; set; }
        public string Defects { get; set; }
        public string Remark { get; set; }
        public string Parallelism { get; set; }
        public string DimensionActual { get; set; }

    }
}
