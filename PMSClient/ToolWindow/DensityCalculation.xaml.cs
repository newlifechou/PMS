﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PMSClient.ToolWindow
{
    /// <summary>
    /// DensityCalculation.xaml 的交互逻辑
    /// </summary>
    public partial class DensityCalculation : Window
    {
        public DensityCalculation()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double w = 0, d = 0, t = 0;
            try
            {
                double.TryParse(Weight.Text.Trim(), out w);
                double.TryParse(Diameter.Text.Trim(), out d);
                double.TryParse(Thickness.Text.Trim(), out t);

                double v = Math.PI * d * d / 4 * t/1000;
                double density = w / v;
                Density.Text = density.ToString("F2");
            }
            catch (Exception)
            {

            }
        }
    }
}
