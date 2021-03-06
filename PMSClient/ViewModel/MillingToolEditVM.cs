﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PMSClient.ExtraService;
using PMSClient.ToolService;

namespace PMSClient.ViewModel
{
    public class MillingToolEditVM : BaseViewModelEdit
    {
        public MillingToolEditVM()
        {
            Intialize();
        }

        private void Intialize()
        {
            GiveUp = new RelayCommand(ActionGiveUp);
            Save = new RelayCommand(ActionSave);
            States = new List<string>();
            PMSBasicDataService.SetListDS<PMSCommon.ToolState>(States);
        }

        private void ActionGiveUp()
        {
            GoBack();
        }

        public void SetNew()
        {
            IsNew = true;
            var model = new DcToolSieve();
            model.Id = Guid.NewGuid();
            model.CreateTime = DateTime.Now;
            model.Creator = PMSHelper.CurrentSession.CurrentUser.UserName;
            model.State = PMSCommon.SimpleState.正常.ToString();
            model.Manufacture = "未知";
            model.SearchID = "S";
            model.BoxNumber = "B";
            model.Specification = "300mm-200mesh";
            model.MaterialGroup = "A-B";
            model.StartTime = DateTime.Now;
            model.StopTime = DateTime.Now.AddYears(2);
            model.State = PMSCommon.SimpleState.正常.ToString();
            model.Remark = "无";

            CurrentToolSieve = model;
        }

        public void SetDuplicate(DcToolSieve obj)
        {
            IsNew = true;
            var model = new DcToolSieve();
            model.Id = Guid.NewGuid();
            model.CreateTime = DateTime.Now;
            model.Creator = PMSHelper.CurrentSession.CurrentUser.UserName;
            model.State = PMSCommon.SimpleState.正常.ToString();
            model.Manufacture = obj.Manufacture;
            model.SearchID = "S";
            model.BoxNumber = obj.BoxNumber;
            model.Specification = obj.Specification;
            model.MaterialGroup = obj.MaterialGroup;
            model.StartTime = DateTime.Now;
            model.StopTime = DateTime.Now.AddYears(2);
            model.State = PMSCommon.SimpleState.正常.ToString();
            model.Remark = obj.Remark;

            CurrentToolSieve = model;
        }
        public void SetEdit(DcToolSieve model)
        {
            if (model != null)
            {
                IsNew = false;
                CurrentToolSieve = model;
            }
        }
        private void GoBack()
        {
            NavigationService.GoTo(PMSViews.MillingTool);
        }

        private void ActionSave()
        {
            if (!PMSDialogService.ShowYesNo("请问", "确定保存这条记录?"))
            {
                return;
            }
            if (CurrentToolSieve.State == "作废")
            {
                if (!PMSDialogService.ShowYesNo("请问", "确定要作废吗？"))
                {
                    return;
                }
            }
            try
            {

                using (var service = new ToolSieveServiceClient())
                {

                    if (IsNew)
                    {
                        //检查是否存在通过S号
                        int check_count1 = 0, check_count2 = 0;
                        if (CurrentToolSieve.SearchID != "S")
                        {
                            check_count1 = service.CheckToolSieveExist(CurrentToolSieve.SearchID);
                            PMSDialogService.ShowWarning($"同号[筛]已经有{check_count1}个了");
                        }
                        if (CurrentToolSieve.BoxNumber != "B")
                        {
                            check_count2 = service.CheckToolMillingBoxExist(CurrentToolSieve.BoxNumber);
                            PMSDialogService.ShowWarning($"同号[箱]已经有{check_count2}个了");
                        }

                        service.AddToolSieve(CurrentToolSieve);
                    }
                    else
                    {
                        service.UpdateToolSieve(CurrentToolSieve);
                    }
                }
                PMSHelper.ViewModels.MillingTool.Refresh();
                GoBack();
            }
            catch (Exception ex)
            {
                PMSHelper.CurrentLog.Error(ex);
            }
        }
        #region 属性

        private DcToolSieve currentToolSieve;
        public DcToolSieve CurrentToolSieve
        {
            get
            {
                return currentToolSieve;
            }
            set
            {
                currentToolSieve = value;
                RaisePropertyChanged(nameof(CurrentToolSieve));
            }
        }

        public List<String> States { get; set; }

        #endregion
    }
}
