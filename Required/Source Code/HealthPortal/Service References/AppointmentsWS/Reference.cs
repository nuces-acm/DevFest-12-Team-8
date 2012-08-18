﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthPortal.AppointmentsWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AppointmentsWS.IAppointmentService")]
    public interface IAppointmentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointmentService/GetAppointmentDetails", ReplyAction="http://tempuri.org/IAppointmentService/GetAppointmentDetailsResponse")]
        System.Collections.Generic.Dictionary<string, object> GetAppointmentDetails(ulong appointmentID, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointmentService/GetAppointment", ReplyAction="http://tempuri.org/IAppointmentService/GetAppointmentResponse")]
        System.Collections.Generic.Dictionary<string, object> GetAppointment(string patientUsername, string patientPassword, uint hospitalID, ulong departmentID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAppointmentServiceChannel : HealthPortal.AppointmentsWS.IAppointmentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AppointmentServiceClient : System.ServiceModel.ClientBase<HealthPortal.AppointmentsWS.IAppointmentService>, HealthPortal.AppointmentsWS.IAppointmentService {
        
        public AppointmentServiceClient() {
        }
        
        public AppointmentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AppointmentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AppointmentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AppointmentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetAppointmentDetails(ulong appointmentID, string username, string password) {
            return base.Channel.GetAppointmentDetails(appointmentID, username, password);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetAppointment(string patientUsername, string patientPassword, uint hospitalID, ulong departmentID) {
            return base.Channel.GetAppointment(patientUsername, patientPassword, hospitalID, departmentID);
        }
    }
}