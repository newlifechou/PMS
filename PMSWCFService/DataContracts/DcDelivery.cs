﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PMSWCFService.DataContracts
{
    //发货单
    [DataContract]
    public class DcDelivery
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public string DeliveryName { get; set; }
        [DataMember]
        public string InvoiceNumber { get; set; }
        [DataMember]
        public string DeliveryNumber { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime ShipTime { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string PackageType { get; set; }//木箱 纸箱 塑料箱
        [DataMember]
        public string PackageInformation { get; set; }//包装重量等细节信息
        [DataMember]
        public string State { get; set; }//取消，未审核，审核通过，已发货

    }
}