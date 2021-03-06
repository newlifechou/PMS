﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PMSCommon;
using PMSClient.MainService;
using System.Collections.ObjectModel;

namespace PMSClient.ViewModel
{
    public class MissonUnCompletedVM : BaseViewModelPage
    {
        public MissonUnCompletedVM()
        {
            InitializeProperties();
            InitializeCommands();
            SetPageParametersWhenConditionChange();
        }

        public void SetSearchCondition(string composition, string pminumber)
        {
            SearchCompositionStandard = composition;
            SearchPMINumber = pminumber;
            //需要重新激发一下
            RaisePropertyChanged(nameof(SearchCompositionStandard));
            RaisePropertyChanged(nameof(SearchPMINumber));
            SetPageParametersWhenConditionChange();
        }

        public void RefreshData()
        {
            ActionSelectionChanged(CurrentSelectItem);
        }

        private void InitializeProperties()
        {
            missonTarget = 0;
            SearchCompositionStandard = SearchPMINumber = "";
            Missons = new ObservableCollection<DcOrder>();
            PlanVHPs = new ObservableCollection<DcPlanVHP>();
        }
        private void InitializeCommands()
        {
            GoToPlan = new RelayCommand(ActionGoToPlan, CanGoToPlan);
            GoToMisson = new RelayCommand(() => NavigationService.GoTo(PMSViews.Misson), CanGoToMisson);
            GoToMaterialNeed = new RelayCommand(() => NavigationService.GoTo(PMSViews.MaterialNeed));

            Search = new RelayCommand(ActionSearch, CanSearch);
            PageChanged = new RelayCommand(ActionPaging);
            AddPlan = new RelayCommand<DcOrder>(ActionAddPlan, CanAddPlan);
            Finish = new RelayCommand<DcOrder>(ActionFinish, CanFinish);
            EditPlan = new RelayCommand<DcPlanVHP>(ActionEditPlan, CanEditPlan);
            DuplicatePlan = new RelayCommand<DcPlanVHP>(ActionDuplicatePlan, CanDuplicatePlan);
            ChangeOrder = new RelayCommand<DcPlanVHP>(ActionChangeOrder, CanChangeOrder);

            SelectionChanged = new RelayCommand<DcOrder>(ActionSelectionChanged);
            Refresh = new RelayCommand(ActionRefresh);
            GiveUp = new RelayCommand(() => NavigationService.GoTo(PMSViews.Misson));
            FindMaterial = new RelayCommand<DcOrder>(ActionFindMaterial, CanFindMaterial);
        }

        private void ActionChangeOrder(DcPlanVHP obj)
        {
            VMHelper.MissonVMHelper.UpdateSpecialRequirement(obj);
        }

        private bool CanChangeOrder(DcPlanVHP arg)
        {
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan);
        }

        private void ActionGoToPlan()
        {
            View.PlanWindow pw = new View.PlanWindow();
            pw.Show();
        }

        private bool CanFindMaterial(DcOrder model)
        {
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan);
        }

        private void ActionFindMaterial(DcOrder model)
        {
            if (model != null)
            {
                PMSHelper.ViewModels.MaterialInventoryIn.SetSearchCondition("", model.PMINumber);
                //NavigationService.GoTo(PMSViews.MaterialInventoryIn);
                View.MaterialInventoryInWindow miw = new View.MaterialInventoryInWindow();
                miw.Show();
            }
        }

        private bool CanFinish(DcOrder arg)
        {
            if (arg == null)
            {
                return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan);
            }
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan) && MissonStateConverter(arg.State);
        }

        private void ActionFinish(DcOrder model)
        {
            //样品信息提示
            //if (!model.SampleNeed.Contains("无需") && !model.SampleForAnlysis.Contains("无需"))
            //{
            //    PMSDialogService.ShowWarning("提示：请注意，该任务可能有【样品要求】，请确定准备了样品");
            //}

            if (!PMSDialogService.ShowYesNo("请问", "请问确定完成了这个任务了吗？"))
            {
                return;
            }
            try
            {
                model.FinishTime = DateTime.Now;
                model.State = PMSCommon.OrderState.生产完成.ToString();
                using (var service = new OrderServiceClient())
                {
                    service.UpdateOrderByUID(model, PMSHelper.CurrentSession.CurrentUser.UserName);
                }
                SetPageParametersWhenConditionChange();
            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }

        private bool CanGoToMisson()
        {
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.ReadPlan);
        }

        private bool CanGoToPlan()
        {
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.ReadPlan);
        }

        private bool CanSearch()
        {
            return !(String.IsNullOrEmpty(SearchPMINumber) &&
                string.IsNullOrEmpty(SearchCompositionStandard));
        }

        private void ActionSearch()
        {
            SetPageParametersWhenConditionChange();
        }

        private bool CanDuplicatePlan(DcPlanVHP arg)
        {
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan) && MissonStateConverter(CurrentSelectItem.State);
        }

        private bool CanEditPlan(DcPlanVHP arg)
        {
            bool isUsed = true;
            if (arg != null)
            {
                isUsed = arg.PlanDate >= DateTime.Today;
            }
            bool isOK = Helpers.AccessHelper.IsAdmin() || (PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan) &&
                MissonStateConverter(CurrentSelectItem.State) && isUsed);
            return isOK;
        }
        /// <summary>
        /// 权限控制=编辑任务
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanAddPlan(DcOrder arg)
        {
            if (arg == null)
            {
                return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan);
            }
            return PMSHelper.CurrentSession.IsAuthorized(PMSAccess.EditPlan) && MissonStateConverter(arg.State);
        }

        private bool MissonStateConverter(string state)
        {
            return state == PMSCommon.OrderState.未完成.ToString();
        }

        private void ActionRefresh()
        {
            SearchPMINumber = SearchCompositionStandard = "";
            SetPageParametersWhenConditionChange();
        }

        private void ActionSelectionChanged(DcOrder model)
        {
            if (model != null)
            {
                using (var service = new PlanVHPServiceClient())
                {
                    var result = service.GetVHPPlansByOrderID(model.ID);
                    PlanVHPs.Clear();
                    result.ToList().ForEach(i => PlanVHPs.Add(i));
                }
                CurrentSelectItem = model;
            }
        }

        private void ActionDuplicatePlan(DcPlanVHP plan)
        {
            if (PMSDialogService.ShowYesNo("请问", "确定复用这条记录？"))
            {
                if (plan != null)
                {

                    PMSHelper.ViewModels.PlanEdit.SetDuplicate(plan);
                    NavigationService.GoTo(PMSViews.PlanEdit);
                }
            }

        }

        private void ActionEditPlan(DcPlanVHP plan)
        {
            if (plan != null)
            {
                if (plan.IsLocked && !Helpers.AccessHelper.IsAdmin())
                {
                    PMSDialogService.ShowWarning("该计划已经被【热压组】锁定执行，不允许再修改.\r\n如果一定要修改,请联系【热压组】解锁");
                    return;
                }
                PMSHelper.ViewModels.PlanEdit.SetEdit(plan);
                NavigationService.GoTo(PMSViews.PlanEdit);
            }
        }

        private void ActionAddPlan(DcOrder order)
        {
            if (order != null)
            {
                PMSHelper.ViewModels.PlanEdit.SetNew(order);
                NavigationService.GoTo(PMSViews.PlanEdit);
            }
        }

        private void SetPageParametersWhenConditionChange()
        {
            try
            {
                PageIndex = 1;
                PageSize = 30;
                var service = new MissonServiceClient();
                RecordCount = service.GetMissonUnCompletedCount2(SearchCompositionStandard, SearchPMINumber);

                MissonTarget = RecordCount;
                service.Close();
                ActionPaging();
            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }
        /// <summary>
        /// 分页动作的时候读入数据
        /// </summary>
        private void ActionPaging()
        {
            int skip, take = 0;
            skip = (PageIndex - 1) * PageSize;
            take = PageSize;
            var service = new MissonServiceClient();
            var orders = service.GetMissonUnCompleted(skip, take, SearchCompositionStandard, SearchPMINumber);
            service.Close();
            Missons.Clear();
            orders.ToList().ForEach(o => Missons.Add(o));

            CurrentSelectItem = orders.FirstOrDefault();
            ActionSelectionChanged(CurrentSelectItem);
        }

        #region Proeperties

        public ObservableCollection<DcOrder> Missons { get; set; }
        public ObservableCollection<DcPlanVHP> PlanVHPs { get; set; }

        private DcOrder currentSelectItem;
        public DcOrder CurrentSelectItem
        {
            get { return currentSelectItem; }
            set { currentSelectItem = value; RaisePropertyChanged(nameof(CurrentSelectItem)); }
        }


        private string searchCompositionStandard;

        public string SearchCompositionStandard
        {
            get { return searchCompositionStandard; }
            set { searchCompositionStandard = value; RaisePropertyChanged((SearchCompositionStandard)); }
        }
        private string searchPMINumber;

        public string SearchPMINumber
        {
            get { return searchPMINumber; }
            set { searchPMINumber = value; RaisePropertyChanged((SearchPMINumber)); }
        }
        private int missonTarget;

        public int MissonTarget
        {
            get { return missonTarget; }
            set { missonTarget = value; RaisePropertyChanged(nameof(MissonTarget)); }
        }



        #endregion

        #region Commands
        public RelayCommand GoToMisson { get; private set; }
        public RelayCommand GoToPlan { get; private set; }
        public RelayCommand GoToMaterialNeed { get; private set; }
        public RelayCommand Refresh { get; set; }
        public RelayCommand<DcOrder> AddPlan { get; set; }
        public RelayCommand<DcOrder> Finish { get; set; }
        public RelayCommand<DcPlanVHP> EditPlan { get; set; }
        public RelayCommand<DcPlanVHP> DuplicatePlan { get; set; }
        public RelayCommand<DcPlanVHP> ChangeOrder { get; set; }
        public RelayCommand<DcOrder> SelectionChanged { get; set; }
        public RelayCommand GiveUp { get; set; }
        public RelayCommand<DcOrder> FindMaterial { get; set; }
        #endregion
    }
}
