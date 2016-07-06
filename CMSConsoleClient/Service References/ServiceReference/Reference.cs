﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMSConsoleClient.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ICommonService")]
    public interface ICommonService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/CheckForNewVersion", ReplyAction="http://tempuri.org/ICommonService/CheckForNewVersionResponse")]
        bool CheckForNewVersion(string clientVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/CheckForNewVersion", ReplyAction="http://tempuri.org/ICommonService/CheckForNewVersionResponse")]
        System.Threading.Tasks.Task<bool> CheckForNewVersionAsync(string clientVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/GetFileNames", ReplyAction="http://tempuri.org/ICommonService/GetFileNamesResponse")]
        string[] GetFileNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/GetFileNames", ReplyAction="http://tempuri.org/ICommonService/GetFileNamesResponse")]
        System.Threading.Tasks.Task<string[]> GetFileNamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/GetFileContent", ReplyAction="http://tempuri.org/ICommonService/GetFileContentResponse")]
        byte[] GetFileContent(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommonService/GetFileContent", ReplyAction="http://tempuri.org/ICommonService/GetFileContentResponse")]
        System.Threading.Tasks.Task<byte[]> GetFileContentAsync(string fileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommonServiceChannel : CMSConsoleClient.ServiceReference.ICommonService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommonServiceClient : System.ServiceModel.ClientBase<CMSConsoleClient.ServiceReference.ICommonService>, CMSConsoleClient.ServiceReference.ICommonService {
        
        public CommonServiceClient() {
        }
        
        public CommonServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommonServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommonServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommonServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CheckForNewVersion(string clientVersion) {
            return base.Channel.CheckForNewVersion(clientVersion);
        }
        
        public System.Threading.Tasks.Task<bool> CheckForNewVersionAsync(string clientVersion) {
            return base.Channel.CheckForNewVersionAsync(clientVersion);
        }
        
        public string[] GetFileNames() {
            return base.Channel.GetFileNames();
        }
        
        public System.Threading.Tasks.Task<string[]> GetFileNamesAsync() {
            return base.Channel.GetFileNamesAsync();
        }
        
        public byte[] GetFileContent(string fileName) {
            return base.Channel.GetFileContent(fileName);
        }
        
        public System.Threading.Tasks.Task<byte[]> GetFileContentAsync(string fileName) {
            return base.Channel.GetFileContentAsync(fileName);
        }
    }
}
