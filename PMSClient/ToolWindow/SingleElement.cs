﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSClient.ToolWindow.Model
{
    public class SingleElement
    {
        public SingleElement()
        {
            Element = "";
            Ratio = 0;
            Offset = Properties.Settings.Default.XRFOffset;
            RealValues = new List<double>();
            Average = 0;
        }
        public string Element { get; set; }
        public double Ratio { get; set; }
        public double Offset { get; set; }

        public List<double> RealValues { get; set; }
        public double Average { get; set; }

    }
}
