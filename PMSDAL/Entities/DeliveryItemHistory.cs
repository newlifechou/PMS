﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSDAL
{
    /// <summary>
    /// 送货单项目
    /// 不涉及过多产品具体信息，在所有产品和样品之间通用
    /// </summary>
    public class DeliveryItemHistory
    {
        public Guid ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public string ProductType { get; set; }//裸靶 or Bonding or其他
        public string ProductID { get; set; }
        public string Composition { get; set; }
        public string Abbr { get; set; }
        public string Customer { get; set; }
        public string PO { get; set; }
        public string Weight { get; set; }
        public string DetailRecord { get; set; }//复杂的信息写在这里
        public string Dimension { get; set; }
        public string DimensionActual { get; set; }
        public string Defects { get; set; }

        public int PackNumber { get; set; }//箱子号
        public string Position { get; set; }//入库库房编号，位置编号，unknown，成品库房 产品架A
        public int OrderNumber { get; set; }

        public string Remark { get; set; }

        public string State { get; set; }

        public Guid DeliveryID { get; set; }


        //操作者和操作时间
        [Key]
        public Guid HistoryID { get; set; }
        public string Operator { get; set; }
        public DateTime OperateTime { get; set; }
    }
}
