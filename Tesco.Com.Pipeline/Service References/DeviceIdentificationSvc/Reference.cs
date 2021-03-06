﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tesco.Com.Pipeline.DeviceIdentificationSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestMessage", Namespace="http://tesco.com/appstore/messages/1")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Tesco.Com.Pipeline.DeviceIdentificationSvc.ServiceRequestOfGetDeviceFamilyResponsePCX_PtJya))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Tesco.Com.Pipeline.DeviceIdentificationSvc.GetDeviceFamilyRequest))]
    public partial class RequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext callContextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string messageIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string requestNameField;
        
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
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext callContext {
            get {
                return this.callContextField;
            }
            set {
                if ((object.ReferenceEquals(this.callContextField, value) != true)) {
                    this.callContextField = value;
                    this.RaisePropertyChanged("callContext");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string messageId {
            get {
                return this.messageIdField;
            }
            set {
                if ((object.ReferenceEquals(this.messageIdField, value) != true)) {
                    this.messageIdField = value;
                    this.RaisePropertyChanged("messageId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string requestName {
            get {
                return this.requestNameField;
            }
            set {
                if ((object.ReferenceEquals(this.requestNameField, value) != true)) {
                    this.requestNameField = value;
                    this.RaisePropertyChanged("requestName");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallContext", Namespace="")]
    [System.SerializableAttribute()]
    public partial class CallContext : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string channelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string businessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string customerSegmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tesco.Com.Pipeline.DeviceIdentificationSvc.UserIdentity userIdentityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string storeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string productInstanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string languageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string regionField;
        
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
        public string channel {
            get {
                return this.channelField;
            }
            set {
                if ((object.ReferenceEquals(this.channelField, value) != true)) {
                    this.channelField = value;
                    this.RaisePropertyChanged("channel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string business {
            get {
                return this.businessField;
            }
            set {
                if ((object.ReferenceEquals(this.businessField, value) != true)) {
                    this.businessField = value;
                    this.RaisePropertyChanged("business");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string customerSegment {
            get {
                return this.customerSegmentField;
            }
            set {
                if ((object.ReferenceEquals(this.customerSegmentField, value) != true)) {
                    this.customerSegmentField = value;
                    this.RaisePropertyChanged("customerSegment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.UserIdentity userIdentity {
            get {
                return this.userIdentityField;
            }
            set {
                if ((object.ReferenceEquals(this.userIdentityField, value) != true)) {
                    this.userIdentityField = value;
                    this.RaisePropertyChanged("userIdentity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string storeId {
            get {
                return this.storeIdField;
            }
            set {
                if ((object.ReferenceEquals(this.storeIdField, value) != true)) {
                    this.storeIdField = value;
                    this.RaisePropertyChanged("storeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string productInstance {
            get {
                return this.productInstanceField;
            }
            set {
                if ((object.ReferenceEquals(this.productInstanceField, value) != true)) {
                    this.productInstanceField = value;
                    this.RaisePropertyChanged("productInstance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string language {
            get {
                return this.languageField;
            }
            set {
                if ((object.ReferenceEquals(this.languageField, value) != true)) {
                    this.languageField = value;
                    this.RaisePropertyChanged("language");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string region {
            get {
                return this.regionField;
            }
            set {
                if ((object.ReferenceEquals(this.regionField, value) != true)) {
                    this.regionField = value;
                    this.RaisePropertyChanged("region");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceRequestOfGetDeviceFamilyResponsePCX_PtJya", Namespace="http://schemas.datacontract.org/2004/07/Tesco.Com.AppStore.Core.MessageTypes")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Tesco.Com.Pipeline.DeviceIdentificationSvc.GetDeviceFamilyRequest))]
    public partial class ServiceRequestOfGetDeviceFamilyResponsePCX_PtJya : Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetDeviceFamilyRequest", Namespace="http://schemas.datacontract.org/2004/07/Tesco.Com.AppStore.DeviceIdentification.M" +
        "essages")]
    [System.SerializableAttribute()]
    public partial class GetDeviceFamilyRequest : Tesco.Com.Pipeline.DeviceIdentificationSvc.ServiceRequestOfGetDeviceFamilyResponsePCX_PtJya {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string userAgentField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string userAgent {
            get {
                return this.userAgentField;
            }
            set {
                if ((object.ReferenceEquals(this.userAgentField, value) != true)) {
                    this.userAgentField = value;
                    this.RaisePropertyChanged("userAgent");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserIdentity", Namespace="")]
    [System.SerializableAttribute()]
    public partial class UserIdentity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthenticationTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAuthenticatedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string AuthenticationType {
            get {
                return this.AuthenticationTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthenticationTypeField, value) != true)) {
                    this.AuthenticationTypeField = value;
                    this.RaisePropertyChanged("AuthenticationType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool IsAuthenticated {
            get {
                return this.IsAuthenticatedField;
            }
            set {
                if ((this.IsAuthenticatedField.Equals(value) != true)) {
                    this.IsAuthenticatedField = value;
                    this.RaisePropertyChanged("IsAuthenticated");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseMessage", Namespace="http://tesco.com/appstore/messages/1")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Tesco.Com.Pipeline.DeviceIdentificationSvc.GetDeviceFamilyResponse))]
    public partial class ResponseMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string errorDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string errorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string requestMessageIdField;
        
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
        public string errorDetails {
            get {
                return this.errorDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.errorDetailsField, value) != true)) {
                    this.errorDetailsField = value;
                    this.RaisePropertyChanged("errorDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.errorMessageField, value) != true)) {
                    this.errorMessageField = value;
                    this.RaisePropertyChanged("errorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string requestMessageId {
            get {
                return this.requestMessageIdField;
            }
            set {
                if ((object.ReferenceEquals(this.requestMessageIdField, value) != true)) {
                    this.requestMessageIdField = value;
                    this.RaisePropertyChanged("requestMessageId");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetDeviceFamilyResponse", Namespace="http://schemas.datacontract.org/2004/07/Tesco.Com.AppStore.DeviceIdentification.M" +
        "essages")]
    [System.SerializableAttribute()]
    public partial class GetDeviceFamilyResponse : Tesco.Com.Pipeline.DeviceIdentificationSvc.ResponseMessage {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily Result {
            get {
                return this.ResultField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultField, value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeviceFamily", Namespace="http://schemas.datacontract.org/2004/07/Tesco.Com.AppStore.DeviceIdentification")]
    [System.SerializableAttribute()]
    public partial class DeviceFamily : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserAgentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tesco.Com.Pipeline.DeviceIdentificationSvc.Capability[] capabilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceType deviceTypeField;
        
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
        public string DeviceId {
            get {
                return this.DeviceIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceIdField, value) != true)) {
                    this.DeviceIdField = value;
                    this.RaisePropertyChanged("DeviceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserAgent {
            get {
                return this.UserAgentField;
            }
            set {
                if ((object.ReferenceEquals(this.UserAgentField, value) != true)) {
                    this.UserAgentField = value;
                    this.RaisePropertyChanged("UserAgent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.Capability[] capabilities {
            get {
                return this.capabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.capabilitiesField, value) != true)) {
                    this.capabilitiesField = value;
                    this.RaisePropertyChanged("capabilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceType deviceType {
            get {
                return this.deviceTypeField;
            }
            set {
                if ((this.deviceTypeField.Equals(value) != true)) {
                    this.deviceTypeField = value;
                    this.RaisePropertyChanged("deviceType");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Capability", Namespace="http://schemas.datacontract.org/2004/07/Tesco.Com.AppStore.DeviceIdentification")]
    [System.SerializableAttribute()]
    public partial class Capability : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeviceType", Namespace="")]
    public enum DeviceType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DeviceNotFound = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PC = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Mobile = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Tablet = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DeviceIdentificationSvc.IDeviceIdentificationService")]
    public interface IDeviceIdentificationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceIdentificationService/GetDeviceFamily", ReplyAction="http://tempuri.org/IDeviceIdentificationService/GetDeviceFamilyResponse")]
        Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily GetDeviceFamily(string userAgent, Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext context);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceIdentificationService/GetDeviceFamily", ReplyAction="http://tempuri.org/IDeviceIdentificationService/GetDeviceFamilyResponse")]
        System.Threading.Tasks.Task<Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily> GetDeviceFamilyAsync(string userAgent, Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext context);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeviceIdentificationServiceChannel : Tesco.Com.Pipeline.DeviceIdentificationSvc.IDeviceIdentificationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeviceIdentificationServiceClient : System.ServiceModel.ClientBase<Tesco.Com.Pipeline.DeviceIdentificationSvc.IDeviceIdentificationService>, Tesco.Com.Pipeline.DeviceIdentificationSvc.IDeviceIdentificationService {
        
        public DeviceIdentificationServiceClient() {
        }
        
        public DeviceIdentificationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeviceIdentificationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceIdentificationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceIdentificationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily GetDeviceFamily(string userAgent, Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext context) {
            return base.Channel.GetDeviceFamily(userAgent, context);
        }
        
        public System.Threading.Tasks.Task<Tesco.Com.Pipeline.DeviceIdentificationSvc.DeviceFamily> GetDeviceFamilyAsync(string userAgent, Tesco.Com.Pipeline.DeviceIdentificationSvc.CallContext context) {
            return base.Channel.GetDeviceFamilyAsync(userAgent, context);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://tesco.com/appstore/proxy/1", ConfigurationName="DeviceIdentificationSvc.IRemoteServiceProxyContract")]
    public interface IRemoteServiceProxyContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/Send", ReplyAction="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendResponse")]
        Tesco.Com.Pipeline.DeviceIdentificationSvc.ResponseMessage Send(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/Send", ReplyAction="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendResponse")]
        System.Threading.Tasks.Task<Tesco.Com.Pipeline.DeviceIdentificationSvc.ResponseMessage> SendAsync(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendRequestXml", ReplyAction="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendRequestXmlRespo" +
            "nse")]
        string SendRequestXml(string requestXml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendRequestXml", ReplyAction="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/SendRequestXmlRespo" +
            "nse")]
        System.Threading.Tasks.Task<string> SendRequestXmlAsync(string requestXml);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/Post")]
        void Post(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tesco.com/appstore/proxy/1/IRemoteServiceProxyContract/Post")]
        System.Threading.Tasks.Task PostAsync(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRemoteServiceProxyContractChannel : Tesco.Com.Pipeline.DeviceIdentificationSvc.IRemoteServiceProxyContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RemoteServiceProxyContractClient : System.ServiceModel.ClientBase<Tesco.Com.Pipeline.DeviceIdentificationSvc.IRemoteServiceProxyContract>, Tesco.Com.Pipeline.DeviceIdentificationSvc.IRemoteServiceProxyContract {
        
        public RemoteServiceProxyContractClient() {
        }
        
        public RemoteServiceProxyContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RemoteServiceProxyContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteServiceProxyContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteServiceProxyContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Tesco.Com.Pipeline.DeviceIdentificationSvc.ResponseMessage Send(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request) {
            return base.Channel.Send(request);
        }
        
        public System.Threading.Tasks.Task<Tesco.Com.Pipeline.DeviceIdentificationSvc.ResponseMessage> SendAsync(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request) {
            return base.Channel.SendAsync(request);
        }
        
        public string SendRequestXml(string requestXml) {
            return base.Channel.SendRequestXml(requestXml);
        }
        
        public System.Threading.Tasks.Task<string> SendRequestXmlAsync(string requestXml) {
            return base.Channel.SendRequestXmlAsync(requestXml);
        }
        
        public void Post(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request) {
            base.Channel.Post(request);
        }
        
        public System.Threading.Tasks.Task PostAsync(Tesco.Com.Pipeline.DeviceIdentificationSvc.RequestMessage request) {
            return base.Channel.PostAsync(request);
        }
    }
}
