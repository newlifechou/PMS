﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMSClient.StatisticService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DcStatistic", Namespace="http://schemas.datacontract.org/2004/07/PMSWCFService.DataContracts")]
    [System.SerializableAttribute()]
    public partial class DcStatistic : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StatisticService.IMainStatisticService")]
    public interface IMainStatisticService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByYearResponse")]
        PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByYear();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByYearResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByYearAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticBySeasonResponse")]
        PMSClient.StatisticService.DcStatistic[] GetOrderStatisticBySeason(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticBySeasonResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticBySeasonAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByMonthResponse")]
        PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByMonth(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByMonthResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByMonthAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByCustomer", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByCustomerResponse")]
        PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByCustomer(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetOrderStatisticByCustomer", ReplyAction="http://tempuri.org/IMainStatisticService/GetOrderStatisticByCustomerResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByCustomerAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetMissonStatistic", ReplyAction="http://tempuri.org/IMainStatisticService/GetMissonStatisticResponse")]
        PMSClient.StatisticService.DcStatistic[] GetMissonStatistic();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetMissonStatistic", ReplyAction="http://tempuri.org/IMainStatisticService/GetMissonStatisticResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetMissonStatisticAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByYearResponse")]
        PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByYear();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByYearResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByYearAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByMonthResponse")]
        PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByMonth(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByMonthResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByMonthAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticBySeasonResponse")]
        PMSClient.StatisticService.DcStatistic[] GetPlanStatisticBySeason(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticBySeasonResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticBySeasonAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByDevice", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByDeviceResponse")]
        PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByDevice(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetPlanStatisticByDevice", ReplyAction="http://tempuri.org/IMainStatisticService/GetPlanStatisticByDeviceResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByDeviceAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByYearResponse")]
        PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByYear();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByYearResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByYearAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticBySeasonResponse")]
        PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticBySeason(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticBySeasonResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticBySeasonAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByMonthResponse")]
        PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByMonth(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByMonthResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByMonthAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByProductType", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByProductTypeRespons" +
            "e")]
        PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByProductType(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByProductType", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByProductTypeRespons" +
            "e")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByProductTypeAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByCustomer", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByCustomerResponse")]
        PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByCustomer(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByCustomer", ReplyAction="http://tempuri.org/IMainStatisticService/GetDeliveryStatisticByCustomerResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByCustomerAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByYearResponse")]
        PMSClient.StatisticService.DcStatistic[] GetProductStatisticByYear();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByYear", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByYearResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByYearAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByMonthResponse")]
        PMSClient.StatisticService.DcStatistic[] GetProductStatisticByMonth(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByMonth", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByMonthResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByMonthAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticBySeasonResponse")]
        PMSClient.StatisticService.DcStatistic[] GetProductStatisticBySeason(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticBySeason", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticBySeasonResponse")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticBySeasonAsync(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByProductType", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByProductTypeResponse" +
            "")]
        PMSClient.StatisticService.DcStatistic[] GetProductStatisticByProductType(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainStatisticService/GetProductStatisticByProductType", ReplyAction="http://tempuri.org/IMainStatisticService/GetProductStatisticByProductTypeResponse" +
            "")]
        System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByProductTypeAsync(int year);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMainStatisticServiceChannel : PMSClient.StatisticService.IMainStatisticService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MainStatisticServiceClient : System.ServiceModel.ClientBase<PMSClient.StatisticService.IMainStatisticService>, PMSClient.StatisticService.IMainStatisticService {
        
        public MainStatisticServiceClient() {
        }
        
        public MainStatisticServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MainStatisticServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainStatisticServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainStatisticServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByYear() {
            return base.Channel.GetOrderStatisticByYear();
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByYearAsync() {
            return base.Channel.GetOrderStatisticByYearAsync();
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetOrderStatisticBySeason(int year) {
            return base.Channel.GetOrderStatisticBySeason(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticBySeasonAsync(int year) {
            return base.Channel.GetOrderStatisticBySeasonAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByMonth(int year) {
            return base.Channel.GetOrderStatisticByMonth(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByMonthAsync(int year) {
            return base.Channel.GetOrderStatisticByMonthAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetOrderStatisticByCustomer(int year) {
            return base.Channel.GetOrderStatisticByCustomer(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetOrderStatisticByCustomerAsync(int year) {
            return base.Channel.GetOrderStatisticByCustomerAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetMissonStatistic() {
            return base.Channel.GetMissonStatistic();
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetMissonStatisticAsync() {
            return base.Channel.GetMissonStatisticAsync();
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByYear() {
            return base.Channel.GetPlanStatisticByYear();
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByYearAsync() {
            return base.Channel.GetPlanStatisticByYearAsync();
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByMonth(int year) {
            return base.Channel.GetPlanStatisticByMonth(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByMonthAsync(int year) {
            return base.Channel.GetPlanStatisticByMonthAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetPlanStatisticBySeason(int year) {
            return base.Channel.GetPlanStatisticBySeason(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticBySeasonAsync(int year) {
            return base.Channel.GetPlanStatisticBySeasonAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetPlanStatisticByDevice(int year) {
            return base.Channel.GetPlanStatisticByDevice(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetPlanStatisticByDeviceAsync(int year) {
            return base.Channel.GetPlanStatisticByDeviceAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByYear() {
            return base.Channel.GetDeliveryStatisticByYear();
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByYearAsync() {
            return base.Channel.GetDeliveryStatisticByYearAsync();
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticBySeason(int year) {
            return base.Channel.GetDeliveryStatisticBySeason(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticBySeasonAsync(int year) {
            return base.Channel.GetDeliveryStatisticBySeasonAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByMonth(int year) {
            return base.Channel.GetDeliveryStatisticByMonth(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByMonthAsync(int year) {
            return base.Channel.GetDeliveryStatisticByMonthAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByProductType(int year) {
            return base.Channel.GetDeliveryStatisticByProductType(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByProductTypeAsync(int year) {
            return base.Channel.GetDeliveryStatisticByProductTypeAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetDeliveryStatisticByCustomer(int year) {
            return base.Channel.GetDeliveryStatisticByCustomer(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetDeliveryStatisticByCustomerAsync(int year) {
            return base.Channel.GetDeliveryStatisticByCustomerAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetProductStatisticByYear() {
            return base.Channel.GetProductStatisticByYear();
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByYearAsync() {
            return base.Channel.GetProductStatisticByYearAsync();
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetProductStatisticByMonth(int year) {
            return base.Channel.GetProductStatisticByMonth(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByMonthAsync(int year) {
            return base.Channel.GetProductStatisticByMonthAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetProductStatisticBySeason(int year) {
            return base.Channel.GetProductStatisticBySeason(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticBySeasonAsync(int year) {
            return base.Channel.GetProductStatisticBySeasonAsync(year);
        }
        
        public PMSClient.StatisticService.DcStatistic[] GetProductStatisticByProductType(int year) {
            return base.Channel.GetProductStatisticByProductType(year);
        }
        
        public System.Threading.Tasks.Task<PMSClient.StatisticService.DcStatistic[]> GetProductStatisticByProductTypeAsync(int year) {
            return base.Channel.GetProductStatisticByProductTypeAsync(year);
        }
    }
}
