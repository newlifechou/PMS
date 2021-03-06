﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSModel.Material
{
    public class MaterialOrderItem
    {
        public Guid ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public int State { get; set; }
        public string Composition { get; set; }
        public string Purity { get; set; }
        public string Description { get; set; }
        public string ProvideRawMaterial { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal UnitPrice { get; set; }
        public double Weight { get; set; }



    }
}
