﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceOperaciones {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceOperaciones.IOperaciones")]
    public interface IOperaciones {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Suma", ReplyAction="http://tempuri.org/IOperaciones/SumaResponse")]
        int Suma(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Suma", ReplyAction="http://tempuri.org/IOperaciones/SumaResponse")]
        System.Threading.Tasks.Task<int> SumaAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Saludar", ReplyAction="http://tempuri.org/IOperaciones/SaludarResponse")]
        string Saludar(string Nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperaciones/Saludar", ReplyAction="http://tempuri.org/IOperaciones/SaludarResponse")]
        System.Threading.Tasks.Task<string> SaludarAsync(string Nombre);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOperacionesChannel : PL_MVC.ServiceOperaciones.IOperaciones, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperacionesClient : System.ServiceModel.ClientBase<PL_MVC.ServiceOperaciones.IOperaciones>, PL_MVC.ServiceOperaciones.IOperaciones {
        
        public OperacionesClient() {
        }
        
        public OperacionesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperacionesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacionesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperacionesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Suma(int a, int b) {
            return base.Channel.Suma(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SumaAsync(int a, int b) {
            return base.Channel.SumaAsync(a, b);
        }
        
        public string Saludar(string Nombre) {
            return base.Channel.Saludar(Nombre);
        }
        
        public System.Threading.Tasks.Task<string> SaludarAsync(string Nombre) {
            return base.Channel.SaludarAsync(Nombre);
        }
    }
}