﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSClient
{
    /// <summary>
    /// 新客户端视图Token集合
    /// </summary>
    public enum PMSViews
    {
        LogIn,
        Navigation,
        NavigationWorkFlow,
        Order,
        OrderEdit,
        OrderCheck,
        OrderCheckEdit,
        MaterialNeed,
        MaterialNeedEdit,
        MaterialNeedSelect,
        MaterialOrder,
        MaterialOrderEdit,
        MaterialOrderItemEdit,
        MaterialOrderItemSelect,
        MaterialInventoryIn,
        MaterialInventoryInEdit,
        MaterialInventoryInSelect,
        MaterialInventoryOut,
        MaterialInventoryOutEdit,
        Misson,
        MissonSelect,
        Plan,
        PlanSelect, 
        PlanEdit,
        PlanSearch,
        RecordMilling,
        RecordMillingEdit,
        RecordVHP,
        RecordVHPQuickEdit,
        RecordDeMold,
        RecordDeMoldSelect,
        RecordDeMoldEdit,
        RecordMachine,
        RecordMachineEdit,
        RecordMachineSelect,
        RecordTest,
        RecordTestEdit,
        RecordTestSelect,
        RecordTestDoc,
        RecordBonding,
        RecordBondingEdit,
        RecordBondingSelect,
        Delivery,
        DeliveryEdit,
        DeliveryItemEdit,
        DeliveryItemList,
        Product,
        ProductEdit,
        ProductSelect,
        StatisticOrder,
        StatisticPlan,
        StatisticDelivery,
        Maintanence,
        MaintanenceEdit,
        MaterialNeedCalcuationTool,
        LabelOutPut,
        BDCustomer,
        BDCompound,
        BDVHPDevice,
        BDMold,
        BDDeliveryAddress,
        BDSupplier,
        AdminUser,
        AdminAccesses,
        AdminAccess,
        AdminRole,
        Plate,
        OutSource
    }
}
