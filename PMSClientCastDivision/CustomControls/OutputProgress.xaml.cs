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

namespace PMSClient.CustomControls
{
    /// <summary>
    /// OutputProgress.xaml 的交互逻辑
    /// </summary>
    public partial class OutputProgress : Window
    {
        public OutputProgress()
        {
            InitializeComponent();
        }
        public double Value
        {
            set
            {
                if (value>100)
                {
                    pb.Value = 100;
                }
                if (value<0)
                {
                    pb.Value = 0;
                }
                pb.Value = value;
            }
        }
    }
}
