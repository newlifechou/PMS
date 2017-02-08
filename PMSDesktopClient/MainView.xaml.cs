﻿using PMSDesktopClient.View;
using PMSDesktopClient.ViewModel;

using PMSDesktopClient.View.Sales;
using System;
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
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using PMSCommon;
using PMSDesktopClient.ServiceReference;



namespace PMSDesktopClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new ViewModel.MainWindowVM();
            Messenger.Default.Register<string>(this, NavigationToken.Navigate, ActionNavigate);
            Messenger.Default.Register<NavigationObject>(this, NavigationToken.Edit,ActionEdit);

            NavigateTo(new LogInView());
        }

        private void ActionEdit(NavigationObject obj)
        {
            switch (obj.ViewName)
            {
                case "OrderEditView":
                    var view = new OrderEditView();
                    var vm=new OrderEditVM(obj.ModelObject as DcOrder);
                    view.DataContext = vm;
                    NavigateTo(view);
                    break;
                case "PlanEditView":
                    var planEditView = new PlanEditView();
                    var planEditVM = new PlanEditVM(obj.ModelObject as DcPlanVHP);
                    planEditView.DataContext = planEditVM;
                    NavigateTo(planEditView);
                    break;
                default :
                    break;
            }
        }

        private void NavigateTo(UserControl view)
        {
            mainArea.Content = view;
        }

        private void ActionNavigate(string viewName)
        {
            switch (viewName)
            {
                case "NavigationView":
                    NavigateTo(new NavigationView());
                    break;
                case "OrderView":
                    NavigateTo(new OrderView());
                    break;
                case "OrderEditView":
                    NavigateTo(new OrderEditView());
                    break;
                case "OrderCheckView":
                    NavigateTo(new OrderCheckView());
                    break;
                case "MissonView":
                    NavigateTo(new MissonView());
                    break;
                case "PlanView":
                    NavigateTo(new PlanView());
                    break;
                case "RecordVHPView":
                    NavigateTo(new RecordVHPView());
                    break;
                case "ProductView":
                    NavigateTo(new ProductView());
                    break;
                case "DeliveryView":
                    NavigateTo(new DeliveryView());
                    break;
                case "MaterialNeedView":
                    NavigateTo(new MaterialNeedView());
                    break;
                case "MaterialOrderView":
                    NavigateTo(new MaterialOrderView());
                    break;
                case "MaterialNeedEditView":
                    NavigateTo(new PlanView());
                    break;
                case "MaterialOrderEditView":
                    NavigateTo(new MaterialOrderView());
                    break;
                case "OrderSelectView":
                    NavigateTo(new OrderSelectView());
                    break;
                default:
                    NavigateTo(new NavigationView());
                    break;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            base.OnClosing(e);
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
