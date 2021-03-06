﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PMSCommon;
using PMSClient.SanjieService;
using System.Collections.ObjectModel;
using PMSClient.ReportsHelper;

namespace PMSClient.ViewModel
{
    public class MaterialInventoryInVM : BaseViewModelPage
    {
        public MaterialInventoryInVM()
        {
            InitializeProperties();
            InitializeCommands();
            SetPageParametersWhenConditionChange();
        }

        public void RefreshData()
        {
            SetPageParametersWhenConditionChange();
        }

        private void InitializeProperties()
        {
            SearchComposition = SearchMaterialLot = SearchPMINumber = "";
            MaterialInventoryIns = new ObservableCollection<DcMaterialInventoryIn>();
        }
        private void InitializeCommands()
        {
            PageChanged = new RelayCommand(ActionPaging);
            Search = new RelayCommand(ActionSearch, CanSearch);
            All = new RelayCommand(ActionAll);

            GoToMaterialInventoryOut = new RelayCommand(() => NavigationService.GoTo(PMSViews.MaterialInventoryOut),
                () => PMSHelper.CurrentSession.IsAuthorized(PMSAccess.ReadMaterialInventoryOut));
           
            Doc = new RelayCommand(ActionDoc);
            ShowGDMS = new RelayCommand<DcMaterialInventoryIn>(ActionShowGDMS);
            ShowICPOES = new RelayCommand<DcMaterialInventoryIn>(ActionShowICPOES);
        }

        private void ActionShowICPOES(DcMaterialInventoryIn obj)
        {
            if (obj != null)
            {
                SetKeyValue(obj.ICPOES);
            }
        }

        private void ActionShowGDMS(DcMaterialInventoryIn obj)
        {
            if (obj != null)
            {
                SetKeyValue(obj.GDMS);
            }
        }

        private void SetKeyValue(string testResult)
        {
            if (string.IsNullOrEmpty(testResult)) return;
            var dialog = new WPFControls.KeyValueTestResultReadOnly();
            dialog.KeyStrings = testResult;
            dialog.ShowDialog();

        }

        private void ActionDoc()
        {
            if (!PMSDialogService.ShowYesNo("请问", "确定以[暂入库]橙色项目创建发货单吗？"))
            {
                return;
            }
            try
            {
                var report = new WordMaterialDeliverySheetNew();
                report.Output();
            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }

        private bool CanSearch()
        {
            return !(string.IsNullOrEmpty(SearchComposition) && string.IsNullOrEmpty(SearchMaterialLot) && string.IsNullOrEmpty(SearchPMINumber));
        }

        private void ActionAll()
        {
            SearchComposition = SearchPMINumber = SearchMaterialLot = "";
            SetPageParametersWhenConditionChange();
        }

        private void ActionSearch()
        {
            SetPageParametersWhenConditionChange();
        }

        private void SetPageParametersWhenConditionChange()
        {
            PageIndex = 1;
            PageSize = 30;
            var service = new SanjieServiceClient();
            RecordCount = service.GetMaterialInventoryInCount(SearchComposition, SearchMaterialLot, SearchPMINumber);
            service.Close();
            ActionPaging();
        }
        /// <summary>
        /// 分页动作的时候读入数据
        /// </summary>
        private void ActionPaging()
        {

            int skip, take = 0;
            skip = (PageIndex - 1) * PageSize;
            take = PageSize;
            var service = new SanjieServiceClient();
            var result = service.GetMaterialInventoryIns(skip, take,  SearchComposition, SearchMaterialLot, SearchPMINumber);
            service.Close();
            MaterialInventoryIns.Clear();
            result.ToList().ForEach(o => MaterialInventoryIns.Add(o));
        }

        #region Proeperties
        private string searchComposition;
        public string SearchComposition
        {
            get { return searchComposition; }
            set
            {
                if (searchComposition == value)
                    return;
                searchComposition = value;
                RaisePropertyChanged(() => SearchComposition);
            }
        }

        private string searchMaterialLot;
        public string SearchMaterialLot
        {
            get { return searchMaterialLot; }
            set { searchMaterialLot = value; RaisePropertyChanged(nameof(SearchMaterialLot)); }
        }

        private string searchPMINumber;
        public string SearchPMINumber
        {
            get { return searchPMINumber; }
            set { searchPMINumber = value; RaisePropertyChanged(nameof(SearchPMINumber)); }
        }



        private ObservableCollection<DcMaterialInventoryIn> materialInventoryIns;
        public ObservableCollection<DcMaterialInventoryIn> MaterialInventoryIns
        {
            get { return materialInventoryIns; }
            set { materialInventoryIns = value; RaisePropertyChanged(nameof(MaterialInventoryIns)); }
        }

        #endregion

        #region Commands

        public RelayCommand GoToMaterialInventoryOut { get; set; }

        public RelayCommand Doc { get; set; }
        public RelayCommand<DcMaterialInventoryIn> ShowGDMS { get; set; }
        public RelayCommand<DcMaterialInventoryIn> ShowICPOES { get; set; }
        #endregion



    }
}
