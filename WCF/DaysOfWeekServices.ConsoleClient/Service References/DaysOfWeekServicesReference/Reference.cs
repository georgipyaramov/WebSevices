﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaysOfWeekServices.ConsoleClient.DaysOfWeekServicesReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DaysOfWeekServicesReference.IDaysOfWeekService")]
    public interface IDaysOfWeekService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDaysOfWeekService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDaysOfWeekService/GetDayOfWeekResponse")]
        string GetDayOfWeek(System.DateTime inputDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDaysOfWeekService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDaysOfWeekService/GetDayOfWeekResponse")]
        System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime inputDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDaysOfWeekServiceChannel : DaysOfWeekServices.ConsoleClient.DaysOfWeekServicesReference.IDaysOfWeekService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DaysOfWeekServiceClient : System.ServiceModel.ClientBase<DaysOfWeekServices.ConsoleClient.DaysOfWeekServicesReference.IDaysOfWeekService>, DaysOfWeekServices.ConsoleClient.DaysOfWeekServicesReference.IDaysOfWeekService {
        
        public DaysOfWeekServiceClient() {
        }
        
        public DaysOfWeekServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DaysOfWeekServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DaysOfWeekServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DaysOfWeekServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayOfWeek(System.DateTime inputDate) {
            return base.Channel.GetDayOfWeek(inputDate);
        }
        
        public System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime inputDate) {
            return base.Channel.GetDayOfWeekAsync(inputDate);
        }
    }
}
