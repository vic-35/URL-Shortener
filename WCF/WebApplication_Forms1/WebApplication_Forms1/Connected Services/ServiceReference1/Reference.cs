﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication_Forms1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ret_info", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class Ret_info : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool B_resultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebApplication_Forms1.ServiceReference1.Db[] Db_listField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string S_errorField;
        
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
        public bool B_result {
            get {
                return this.B_resultField;
            }
            set {
                if ((this.B_resultField.Equals(value) != true)) {
                    this.B_resultField = value;
                    this.RaisePropertyChanged("B_result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebApplication_Forms1.ServiceReference1.Db[] Db_list {
            get {
                return this.Db_listField;
            }
            set {
                if ((object.ReferenceEquals(this.Db_listField, value) != true)) {
                    this.Db_listField = value;
                    this.RaisePropertyChanged("Db_list");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string S_error {
            get {
                return this.S_errorField;
            }
            set {
                if ((object.ReferenceEquals(this.S_errorField, value) != true)) {
                    this.S_errorField = value;
                    this.RaisePropertyChanged("S_error");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Db", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class Db : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string S_longField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string S_shortField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string User_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int View_countField;
        
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
        public string S_long {
            get {
                return this.S_longField;
            }
            set {
                if ((object.ReferenceEquals(this.S_longField, value) != true)) {
                    this.S_longField = value;
                    this.RaisePropertyChanged("S_long");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string S_short {
            get {
                return this.S_shortField;
            }
            set {
                if ((object.ReferenceEquals(this.S_shortField, value) != true)) {
                    this.S_shortField = value;
                    this.RaisePropertyChanged("S_short");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string User_id {
            get {
                return this.User_idField;
            }
            set {
                if ((object.ReferenceEquals(this.User_idField, value) != true)) {
                    this.User_idField = value;
                    this.RaisePropertyChanged("User_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int View_count {
            get {
                return this.View_countField;
            }
            set {
                if ((this.View_countField.Equals(value) != true)) {
                    this.View_countField = value;
                    this.RaisePropertyChanged("View_count");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Get", ReplyAction="http://tempuri.org/IService1/GetResponse")]
        WebApplication_Forms1.ServiceReference1.Ret_info Get(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Get", ReplyAction="http://tempuri.org/IService1/GetResponse")]
        System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> GetAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Get1", ReplyAction="http://tempuri.org/IService1/Get1Response")]
        WebApplication_Forms1.ServiceReference1.Ret_info Get1(string id, string id1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Get1", ReplyAction="http://tempuri.org/IService1/Get1Response")]
        System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> Get1Async(string id, string id1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Post", ReplyAction="http://tempuri.org/IService1/PostResponse")]
        WebApplication_Forms1.ServiceReference1.Ret_info Post(WebApplication_Forms1.ServiceReference1.Db j);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Post", ReplyAction="http://tempuri.org/IService1/PostResponse")]
        System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> PostAsync(WebApplication_Forms1.ServiceReference1.Db j);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication_Forms1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication_Forms1.ServiceReference1.IService1>, WebApplication_Forms1.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication_Forms1.ServiceReference1.Ret_info Get(string id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> GetAsync(string id) {
            return base.Channel.GetAsync(id);
        }
        
        public WebApplication_Forms1.ServiceReference1.Ret_info Get1(string id, string id1) {
            return base.Channel.Get1(id, id1);
        }
        
        public System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> Get1Async(string id, string id1) {
            return base.Channel.Get1Async(id, id1);
        }
        
        public WebApplication_Forms1.ServiceReference1.Ret_info Post(WebApplication_Forms1.ServiceReference1.Db j) {
            return base.Channel.Post(j);
        }
        
        public System.Threading.Tasks.Task<WebApplication_Forms1.ServiceReference1.Ret_info> PostAsync(WebApplication_Forms1.ServiceReference1.Db j) {
            return base.Channel.PostAsync(j);
        }
    }
}