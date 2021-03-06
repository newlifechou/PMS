﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSModel
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class PMSRole
    {
        public Guid ID { get; set; }
        public string GroupName { get; set; }
        public string ExtraInformation { get; set; }
        public int CurrentState { get; set; }
        public DateTime CreateTime { get; set; }
        //Navigation
        public virtual ICollection<PMSAccess> Accesses { get; set; }
    }
}
