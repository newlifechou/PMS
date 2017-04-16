﻿using PMSClient.MainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSClient.BasicService;

namespace PMSClient
{
    /// <summary>
    /// 生成ComboBox用的基本数据源
    /// 来自枚举，来自数据库，来自文件
    /// </summary>
    public static class PMSBasicData
    {
        /// <summary>
        /// 传入的T必须是Enum
        /// </summary>
        /// <typeparam name="T">必须是枚举类型</typeparam>
        /// <param name="ds">必须提前new</param>
        public static void SetListDS<T>(List<string> ds)
        {
            if (ds != null)
            {
                ds.Clear();
                GetEnumNames<T>().ToList().ForEach(i => ds.Add(i));
            }
        }
        public static void SetListDS(List<string> source, List<string> target)
        {
            if (target != null)
            {
                target.Clear();
                source.ForEach(i => target.Add(i));
            }
        }

        /// <summary>
        /// 传入的T必须是Enum
        /// </summary>
        private static List<string> GetEnumNames<T>()
        {
            return Enum.GetNames(typeof(T)).ToList();
        }






        //From Enums
        public static string[] OrderStates
        {
            get
            {
                var states = Enum.GetNames(typeof(PMSCommon.OrderState));
                return states;
            }
        }
        public static string[] CommonStates
        {
            get
            {
                var states = Enum.GetNames(typeof(PMSCommon.CommonState));
                return states;
            }
        }
        public static string[] SimpleStates
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.SimpleState));
            }
        }
        public static string[] VHPPlanStates
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.VHPPlanState));
            }
        }
        public static string[] OrderPriorities
        {
            get
            {
                var states = Enum.GetNames(typeof(PMSCommon.OrderPriority));
                return states;
            }
        }
        public static string[] OrderPolicyTypes
        {
            get
            {
                var states = Enum.GetNames(typeof(PMSCommon.OrderPolicyType));
                return states;
            }
        }
        public static string[] TestTypes
        {
            get
            {
                var productTypes = Enum.GetNames(typeof(PMSCommon.TestType));
                return productTypes;
            }
        }
        public static string[] OrderProductTypes
        {
            get
            {
                var productTypes = Enum.GetNames(typeof(PMSCommon.OrderProductType));
                return productTypes;
            }
        }
        public static string[] PackNumbers
        {
            get
            {
                var numbers = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    numbers.Add((i+1).ToString());
                }
                return numbers.ToArray();
            }
        }
        public static string[] ProductTypes
        {
            get
            {
                var productTypes = Enum.GetNames(typeof(PMSCommon.ProductType));
                return productTypes;
            }
        }
        public static string[] ProductStates
        {
            get
            {
                var productTypes = Enum.GetNames(typeof(PMSCommon.ProductState));
                return productTypes;
            }
        }
        public static string[] Countries
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.Country));
            }
        }
        public static string[] PackageTypes
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.PackageType));
            }
        }
        public static string[] GoodPositions
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.GoodPosition));
            }
        }

        public static string[] QuickVHPMessages
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.QuickVHPMessage));
            }
        }
        public static string[] OrderUnits
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.OrderUnit));
            }
        }
        public static string[] MillingTimes
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.MillingTime));
            }
        }
        public static string[] MillingTools
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.MillingTool));
            }
        }
        public static string[] MillingGases
        {
            get
            {
                return Enum.GetNames(typeof(PMSCommon.MillingGas));
            }
        }

        //From Services
        public static DcBDCustomer[] Customers
        {
            get
            {
                using (var service = new CustomerServiceClient())
                {
                    return service.GetCustomer().OrderBy(i => i.CustomerName).ToArray();
                }
            }
        }
        public static DcBDCompound[] Compounds
        {
            get
            {
                using (var service = new CompoundServiceClient())
                {
                    return service.GetAllCompounds().OrderBy(i => i.MaterialName).ToArray();
                }
            }
        }
        public static DcBDVHPDevice[] VHPDevices
        {
            get
            {
                using (var service = new VHPDeviceServiceClient())
                {
                    return service.GetVHPDevice().OrderBy(i => i.CodeName).ToArray();
                }
            }
        }
        public static DcBDVHPProcess[] VHPProcesses
        {
            get
            {
                using (var service = new VHPProcessServiceClient())
                {
                    return service.GetVHPProcess().OrderBy(i=>i.CodeName).ToArray();
                }
            }
        }
        public static DcBDVHPMold[] VHPMolds
        {
            get
            {
                using (var service=new VHPMoldServiceClient())
                {
                    return service.GetVHPMold().OrderBy(i=>i.InnerDiameter).ToArray();
                }
            }
        }




    }
}
