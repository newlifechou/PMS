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
using PMSClient.SanjieService;
using PMSCommon;
using PMSClient.ViewModel;

namespace PMSClient.View
{
    /// <summary>
    /// MaterialOrderView.xaml 的交互逻辑
    /// </summary>
    public partial class MaterialOrderView : UserControl
    {
        public MaterialOrderView()
        {
            InitializeComponent();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DcMaterialOrder order = (DcMaterialOrder)e.Row.DataContext;
            if (order != null)
            {
                switch (order.State)
                {
                    case "未核验":
                        e.Row.Background = this.FindResource("UnCheckedBrush") as SolidColorBrush;
                        break;
                    case "已核验":
                        e.Row.Background = this.FindResource("CheckedBrush") as SolidColorBrush;
                        break;
                    default:
                        break;
                }

            }
        }

        private void DataGrid_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            try
            {
                DcMaterialOrderItem order = (DcMaterialOrderItem)e.Row.DataContext;
                if (order != null)
                {
                    switch (order.State)
                    {
                        case "未核验":
                            e.Row.Background = this.FindResource("UnCheckedBrush") as SolidColorBrush;
                            break;
                        case "暂停":
                            e.Row.Background = this.FindResource("PausedBrush") as SolidColorBrush;
                            break;
                        case "未完成":
                            e.Row.Background = this.FindResource("UnCompletedBrush") as SolidColorBrush;
                            break;
                        case "最终完成":
                            e.Row.Background = this.FindResource("CompletedBrush") as SolidColorBrush;
                            break;
                        case "紧急":
                            e.Row.Background = this.FindResource("EmergencyBrush") as SolidColorBrush;
                            break;
                        default:
                            break;
                    }
                    if (order.State == "未完成" && order.Priority.Contains("紧急"))
                    {
                        e.Row.Background = this.FindResource("EmergencyBrush") as SolidColorBrush;
                    }
                }
            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }
    }
}