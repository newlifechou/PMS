﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PMSCommon;
using PMSDesktopClient.PMSMainService;
using System.Collections.ObjectModel;
using PMSDesktopClient.View;

namespace PMSDesktopClient.ViewModel
{
    public class MaterialNeedVM : ViewModelBase
    {
        public MaterialNeedVM()
        {
            Messenger.Default.Register<MsgObject>(this, VToken.MaterialNeedRefresh, ActionRefresh);
            InitializeProperties();
            InitializeCommands();
            SetPageParametersWhenConditionChange();
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
        private void ActionRefresh(MsgObject obj)
        {
            SetPageParametersWhenConditionChange();
        }

        private void InitializeProperties()
        {
            SearchCompositoinStandard = "";
            MainMaterialNeeds = new ObservableCollection<DcMaterialNeed>();
        }
        private void InitializeCommands()
        {
            GoToNavigation = new RelayCommand(() => NavigationService.GoTo(new MsgObject() { MsgToken=VToken.Navigation}));
            PageChanged = new RelayCommand(ActionPaging);
            Search = new RelayCommand(ActionSearch, CanSearch);
            All = new RelayCommand(ActionAll);

            Add = new RelayCommand(ActionAdd);
            Edit = new RelayCommand<PMSMainService.DcMaterialNeed>(ActionEdit);



        }

        private void ActionEdit(DcMaterialNeed obj)
        {
            if (obj!=null)
            {
                MsgObject msg = new PMSDesktopClient.MsgObject();
                msg.MsgToken = VToken.MaterialNeedEdit;
                msg.MsgModel = new ModelObject() { IsNew = false, Model = obj };

                NavigationService.GoTo(msg);
            }
        }

        private void ActionAdd()
        {
            //转向订单选择页面
            MsgObject msg = new MsgObject();
            msg.MsgToken = VToken.OrderSelect;        
            NavigationService.GoTo(msg);
        }

        private bool CanSearch()
        {
            return !(string.IsNullOrEmpty(SearchCompositoinStandard));
        }

        private void ActionAll()
        {
            SearchCompositoinStandard = "";
            SetPageParametersWhenConditionChange();
        }

        private void ActionSearch()
        {
            SetPageParametersWhenConditionChange();
        }

        private void SetPageParametersWhenConditionChange()
        {
            PageIndex = 1;
            PageSize = 20;
            var service = new MaterialNeedServiceClient();
            RecordCount = service.GetMaterialNeedCountBySearch(SearchCompositoinStandard);
            ActionPaging();
        }
        /// <summary>
        /// 分页动作的时候读入数据
        /// </summary>
        private void ActionPaging()
        {
            var service = new MaterialNeedServiceClient();
            int skip, take = 0;
            skip = (PageIndex - 1) * PageSize;
            take = PageSize;
            var result = service.GetMaterialNeedBySearchInPage(skip, take, SearchCompositoinStandard);
            MainMaterialNeeds.Clear();
            result.ToList<DcMaterialNeed>().ForEach(o => MainMaterialNeeds.Add(o));
        }


        #region PagingProperties
        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = value;
                RaisePropertyChanged(nameof(PageIndex));
            }
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value;
                RaisePropertyChanged(nameof(PageSize));
            }
        }

        private int recordCount;
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                recordCount = value;
                RaisePropertyChanged(nameof(RecordCount));
            }
        }
        #endregion

        #region Proeperties
        private string searchCompositionStandard;
        public string SearchCompositoinStandard
        {
            get { return searchCompositionStandard; }
            set
            {
                if (searchCompositionStandard == value)
                    return;
                searchCompositionStandard = value;
                RaisePropertyChanged(() => SearchCompositoinStandard);
            }
        }





        private ObservableCollection<DcMaterialNeed> mainMaterialNeeds;
        public ObservableCollection<DcMaterialNeed> MainMaterialNeeds
        {
            get { return mainMaterialNeeds; }
            set { mainMaterialNeeds = value; RaisePropertyChanged(nameof(MainMaterialNeeds)); }
        }

        #endregion

        #region Commands
        public RelayCommand GoToNavigation { get; private set; }
        public RelayCommand Search { get; private set; }
        public RelayCommand All { get; set; }
        public RelayCommand Add { get; private set; }
        public RelayCommand<DcMaterialNeed> Edit { get; private set; }
        public RelayCommand PageChanged { get; private set; }
        #endregion



    }
}
