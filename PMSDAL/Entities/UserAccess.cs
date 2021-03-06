﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSDAL
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public class UserAccess
    {
        public Guid ID { get; set; }
        public string AccessName { get; set; }
        public string AccessCode { get; set; }
        public string State { get; set; }
        public string ExtraInformation { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
