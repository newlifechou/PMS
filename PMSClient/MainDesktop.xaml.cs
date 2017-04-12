﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using PMSClient.ViewModel;
using PMSClient.ViewForDesktop;
using PMSClient.MainService;
using PMSClient.Tool;
using System.Timers;

namespace PMSClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainDesktop : Window
    {
        private DesktopViewLocator _views;
        private ToolViewLocator _toolviews;

        public MainDesktop()
        {
            InitializeComponent();
        }
        private Timer _timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _views = PMSHelper.DesktopViews;
            _toolviews = PMSHelper.ToolViews;

            Messenger.Default.Register<PMSViews>(this, MainNavigationToken.Navigate, ActionNavigation);
            Messenger.Default.Register<string>(this, MainNavigationToken.StatusMessage, ActionStatusMessage);

            //设置服务器心跳检测定时器
            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            _timer_Elapsed(this, null);

            //导航到首页
            NavigateTo(_views.LogIn);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var heartbeat = new PMSClient.HeartBeatService.HeartBeatSeriveClient())
                {
                    //System.Diagnostics.Debug.Print(heartbeat.Beat());
                    if (heartbeat.Beat()=="ok")
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            txtHeartBeat.Text = "服务器通信正常";
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            txtHeartBeat.Text = "服务器通信故障";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    txtHeartBeat.Text = ex.Message;
                });
            }
        }

        private void ActionNavigation(PMSViews token)
        {
            RefreshLogInformation();
            PMSHelper.CurrentLog.Log(token.ToString());
            switch (token)
            {
                case PMSViews.LogIn:
                    NavigateTo(_views.LogIn);
                    break;
                case PMSViews.Navigation:
                    NavigateTo(_views.Navigation);
                    break;
                case PMSViews.Order:
                    NavigateTo(_views.Order);
                    break;
                case PMSViews.OrderEdit:
                    NavigateTo(_views.OrderEdit);
                    break;
                case PMSViews.MissonSelect:
                    NavigateTo(_views.MissonSelect);
                    break;
                case PMSViews.OrderCheck:
                    NavigateTo(_views.OrderCheck);
                    break;
                case PMSViews.OrderCheckEdit:
                    NavigateTo(_views.OrderCheckEdit);
                    break;
                case PMSViews.MaterialNeed:
                    NavigateTo(_views.MaterialNeed);
                    break;
                case PMSViews.MaterialNeedEdit:
                    NavigateTo(_views.MaterialNeedEdit);
                    break;
                case PMSViews.MaterialNeedSelect:
                    NavigateTo(_views.MaterialNeedSelect);
                    break;
                case PMSViews.MaterialOrder:
                    NavigateTo(_views.MaterialOrder);
                    break;
                case PMSViews.MaterialOrderEdit:
                    NavigateTo(_views.MaterialOrderEdit);
                    break;
                case PMSViews.MaterialOrderItemEdit:
                    NavigateTo(_views.MaterialOrderItemEdit);
                    break;
                case PMSViews.MaterialInventoryIn:
                    NavigateTo(_views.MaterialInventoryIn);
                    break;
                case PMSViews.MaterialInventoryInEdit:
                    NavigateTo(_views.MaterialInventoryInEdit);
                    break;
                case PMSViews.MaterialInventoryInSelect:
                    NavigateTo(_views.MaterialInventoryInSelect);
                    break;
                case PMSViews.MaterialInventoryOut:
                    NavigateTo(_views.MaterialInventoryOut);
                    break;
                case PMSViews.MaterialInventoryOutEdit:
                    NavigateTo(_views.MaterialInventoryOutEdit);
                    break;
                case PMSViews.Misson:
                    NavigateTo(_views.Misson);
                    break;
                case PMSViews.Plan:
                    NavigateTo(_views.Plan);
                    break;
                case PMSViews.PlanEdit:
                    NavigateTo(_views.PlanEdit);
                    break;
                case PMSViews.PlanSelect:
                    NavigateTo(_views.PlanSelect);
                    break;
                case PMSViews.RecordMilling:
                    NavigateTo(_views.RecordMilling);
                    break;
                case PMSViews.RecordMillingEdit:
                    NavigateTo(_views.RecordMillingEdit);
                    break;
                case PMSViews.RecordVHP:
                    NavigateTo(_views.RecordVHP);
                    break;
                case PMSViews.RecordVHPQuickEdit:
                    NavigateTo(_views.RecordVHPQuickEdit);
                    break;
                case PMSViews.RecordDeMold:
                    NavigateTo(_views.RecordDeMold);
                    break;
                case PMSViews.RecordDeMoldEdit:
                    NavigateTo(_views.RecordDeMoldEdit);
                    break;
                case PMSViews.RecordMachine:
                    NavigateTo(_views.RecordMachine);
                    break;
                case PMSViews.RecordMachineEdit:
                    NavigateTo(_views.RecordMachineEdit);
                    break;
                case PMSViews.RecordTest:
                    NavigateTo(_views.RecordTest);
                    break;
                case PMSViews.RecordTestEdit:
                    NavigateTo(_views.RecordTestEdit);
                    break;
                case PMSViews.RecordTestSelect:
                    NavigateTo(_views.RecordTestSelect);
                    break;
                case PMSViews.RecordDelivery:
                    NavigateTo(_views.RecordDelivery);
                    break;
                case PMSViews.RecordDeliveryEdit:
                    NavigateTo(_views.RecordDeliveryEdit);
                    break;
                case PMSViews.RecordDeliveryItemEdit:
                    NavigateTo(_views.RecordDeliveryItemEdit);
                    break;
                case PMSViews.MaterialNeedCalcuationTool:
                    NavigateTo(_toolviews.MaterialNeedCalculation);
                    break;
                default:
                    break;
            }
        }

        private void RefreshLogInformation()
        {
            var _logInformation = PMSHelper.CurrentSession;
            if (_logInformation.CurrentUser != null)
            {
                txtCurrentUserName.Text = $"当前用户:[{ _logInformation.CurrentUser.RealName}] 角色:[{_logInformation.CurrentUserRole.GroupName}]";
            }
            else
            {
                txtCurrentUserName.Text = "未登录";
            }
        }

        private void ActionStatusMessage(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                txtStateMessage.Text = obj;
            }
            else
            {
                txtStateMessage.Text = "状态栏";
            }
        }



        private void NavigateTo(UserControl view)
        {
            if (view != null)
            {
                mainArea.Content = view;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            base.OnClosing(e);
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
