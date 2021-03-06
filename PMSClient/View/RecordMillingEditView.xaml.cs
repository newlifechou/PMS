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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PMSClient.View
{
    /// <summary>
    /// RecordMillingEdit.xaml 的交互逻辑
    /// </summary>
    public partial class RecordMillingEditView : UserControl
    {
        public RecordMillingEditView()
        {
            InitializeComponent();
        }

        private void BtnCalculation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double weightIn = double.Parse(txtWeightIn.Text.Trim());
                double weightOut = double.Parse(txtWeightOut.Text.Trim());
                double weightRemain = double.Parse(txtWeightRemain.Text.Trim());
                double loss = weightIn - weightOut - weightRemain;
                if (weightIn > 0 && loss >= 0)
                {
                    double ratio = loss / weightIn;
                    txtRatio.Text = ratio.ToString();
                    txtRatio.Focus();
                }

            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }

        private void BtnToolSieve_Click(object sender, RoutedEventArgs e)
        {
            var win = new View.MillingToolWindow();
            win.Show();
        }

        private void SRemark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = e.OriginalSource as Button;
                if (btn != null)
                {
                    PMSMethods.SetTextBoxAppend(TxtRemark,$"{btn.Content.ToString()};");
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
