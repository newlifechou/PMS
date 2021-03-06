﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSDAL.Model
{
    /// <summary>
    /// 模具信息
    /// </summary>
    public class Mold
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string MoldCode { get; set; }//给模具编的，符合人阅读规律的编号
        [Required]
        public string InnerDiameter { get; set; }//模具直径
        public string Height { get; set; }//模具高度
        [Required]
        public string MoldType { get; set; }//模具类型，高强石墨，超强石墨，CFC
        [Required]
        public string State { get; set; }//可用状态

        public DateTime BoughtTime { get; set; }//购买时间

        public string Remark { get; set; }


    }
}
