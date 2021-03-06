﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PMSClient.Components.CscanImageProcess;
using PMSClient.DataProcess.ScanInput;
using PMSClient.MainService;

namespace PMSClient.DataProcess.QuickCheck
{
    public class QuickCheckVM : ViewModelBase
    {
        public QuickCheckVM(DcDelivery delivery)
        {
            if (delivery == null)
                throw new NullReferenceException();

            this.delivery = delivery;

            inputText = "";
            progressValue = 0;
            sourceTarget = $"核验发货清单{delivery.DeliveryName}";
            process = new ProcessQuickCheck();

            Process = new RelayCommand(ActionProcess, CanCheck);
            Check = new RelayCommand(ActionCheck, CanCheck);
            Lots = new ObservableCollection<LotModel>();

        }

        private bool CanCheck()
        {
            return canClick;
        }
        private DcDelivery delivery;

        private ProcessQuickCheck process;
        private bool canClick = true;

        private void ActionCheck()
        {
            ClearLots();
            Task task = new Task(() =>
            {
                canClick = false;
                process.Intialize(InputText);
                process.SetDelivery(delivery);

                process.Check(i =>
                {
                    ProgressValue = i;
                });
                App.Current.Dispatcher.Invoke(() =>
                {
                    RefreshLotsStatus();

                });
                canClick = true;
            });
            task.Start();
        }

        private void ActionProcess()
        {
            if (PMSDialogService.ShowYesNo("请问", "确定继续吗？") == false)
                return;
            ClearLots();
            Task task = new Task(() =>
            {
                canClick = false;
                process.Intialize(InputText);

                process.Process(i =>
                {
                    ProgressValue = i;
                });
                App.Current.Dispatcher.Invoke(() =>
                {
                    RefreshLotsStatus();

                });
                canClick = true;
            });

            task.Start();
        }

        private void ClearLots()
        {
            Lots.Clear();
        }
        private void RefreshLotsStatus()
        {
            Lots.Clear();
            process.Lots.ForEach(i =>
            {
                Lots.Add(i);
            });

            PMSDialogService.Show("结束", "处理结束");

        }


        public ObservableCollection<LotModel> Lots { get; set; }

        #region 属性
        private string inputText;
        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                RaisePropertyChanged(nameof(inputText));
            }
        }

        private double progressValue;
        public double ProgressValue
        {
            get
            {
                return progressValue;
            }
            set
            {
                progressValue = value;
                RaisePropertyChanged(nameof(ProgressValue));
            }
        }

        private string sourceTarget;
        public string SourceTarget
        {
            get
            {
                return sourceTarget;
            }
            set
            {
                sourceTarget = value;
                RaisePropertyChanged(nameof(SourceTarget));
            }
        }
        #endregion
        public RelayCommand Process { get; set; }
        public RelayCommand Check { get; set; }

    }
}
