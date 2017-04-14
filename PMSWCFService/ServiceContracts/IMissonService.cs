﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PMSWCFService.DataContracts;

namespace PMSWCFService.ServiceContracts
{
    [ServiceContract]
    public interface IMissonService
    {
        #region 获取任务
        [OperationContract]
        List<DcOrder> GetMissons(int skip, int take);
        [OperationContract]
        int GetMissonsCount();


        [OperationContract]
        List<DcOrder> GetMissonsBySearch(int skip, int take, string compostion);
        [OperationContract]
        int GetMissonsCountBySearch(string compostion);

        /// <summary>
        /// 按任务id获取Plan，和IPlanVHP契约重复，后面考虑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        List<DcPlanVHP> GetPlans(Guid id);
        #endregion

        #region 获取附带有订单信息任务
        [OperationContract]
        List<DcMissonWithPlan> GetMissonWithPlan(int skip, int take);
        [OperationContract]
        int GetMissonWithPlanCount();


        //Checked状态的计划显示
        [OperationContract]
        List<DcMissonWithPlan> GetMissonWithPlanChecked(int skip, int take);
        [OperationContract]
        int GetMissonWithPlanCheckedCount();


        //按照日期范围获取
        [OperationContract]
        List<DcMissonWithPlan> GetMissonWithPlanCheckedByDateRange(int skip, int take, DateTime dateStart, DateTime dateEnd);
        [OperationContract]
        int GetMissonWithPlanCheckedCountByDateRange(DateTime dateStart, DateTime dateEnd);
        #endregion

        #region 获取附带有订单信息的任务-New
        //获取全部
        [OperationContract]
        List<DcPlanWithMisson> GetPlanWithMisson(int skip, int take);
        [OperationContract]
        int GetPlanWithMissonCount();


        //Checked状态的计划显示
        [OperationContract]
        List<DcPlanWithMisson> GetPlanWithMissonChecked(int skip, int take);
        [OperationContract]
        int GetPlanWithMissonCheckedCount();


        //按照日期范围获取
        [OperationContract]
        List<DcPlanWithMisson> GetPlanWithMissonCheckedByDateRange(int skip, int take, DateTime dateStart, DateTime dateEnd);
        [OperationContract]
        int GetPlanWithMissonCheckedCountByDateRange(DateTime dateStart, DateTime dateEnd);
        #endregion
    }
}
