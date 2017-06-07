﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tippspiel_Verwaltungsclient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Season", Namespace="http://schemas.datacontract.org/2004/07/Tippspiel_Server.Sources.Models")]
    [System.SerializableAttribute()]
    public partial class Season : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SequenceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tippspiel_Verwaltungsclient.ServiceReference1.Team[] TeamsField;
        
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
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
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
        public int Sequence {
            get {
                return this.SequenceField;
            }
            set {
                if ((this.SequenceField.Equals(value) != true)) {
                    this.SequenceField = value;
                    this.RaisePropertyChanged("Sequence");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tippspiel_Verwaltungsclient.ServiceReference1.Team[] Teams {
            get {
                return this.TeamsField;
            }
            set {
                if ((object.ReferenceEquals(this.TeamsField, value) != true)) {
                    this.TeamsField = value;
                    this.RaisePropertyChanged("Teams");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Team", Namespace="http://schemas.datacontract.org/2004/07/Tippspiel_Server.Sources.Models")]
    [System.SerializableAttribute()]
    public partial class Team : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tippspiel_Verwaltungsclient.ServiceReference1.Season[] SeasonsField;
        
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
        public Tippspiel_Verwaltungsclient.ServiceReference1.Season[] Seasons {
            get {
                return this.SeasonsField;
            }
            set {
                if ((object.ReferenceEquals(this.SeasonsField, value) != true)) {
                    this.SeasonsField = value;
                    this.RaisePropertyChanged("Seasons");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISeasonService")]
    public interface ISeasonService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeasonService/GetAllSeasons", ReplyAction="http://tempuri.org/ISeasonService/GetAllSeasonsResponse")]
        Tippspiel_Verwaltungsclient.ServiceReference1.Season[] GetAllSeasons();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeasonService/GetAllSeasons", ReplyAction="http://tempuri.org/ISeasonService/GetAllSeasonsResponse")]
        System.Threading.Tasks.Task<Tippspiel_Verwaltungsclient.ServiceReference1.Season[]> GetAllSeasonsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeasonService/RemoveSeason", ReplyAction="http://tempuri.org/ISeasonService/RemoveSeasonResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Tippspiel_Verwaltungsclient.ServiceReference1.Season[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Tippspiel_Verwaltungsclient.ServiceReference1.Season))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Tippspiel_Verwaltungsclient.ServiceReference1.Team[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Tippspiel_Verwaltungsclient.ServiceReference1.Team))]
        object RemoveSeason();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeasonService/RemoveSeason", ReplyAction="http://tempuri.org/ISeasonService/RemoveSeasonResponse")]
        System.Threading.Tasks.Task<object> RemoveSeasonAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISeasonServiceChannel : Tippspiel_Verwaltungsclient.ServiceReference1.ISeasonService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SeasonServiceClient : System.ServiceModel.ClientBase<Tippspiel_Verwaltungsclient.ServiceReference1.ISeasonService>, Tippspiel_Verwaltungsclient.ServiceReference1.ISeasonService {
        
        public SeasonServiceClient() {
        }
        
        public SeasonServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SeasonServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeasonServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeasonServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Tippspiel_Verwaltungsclient.ServiceReference1.Season[] GetAllSeasons() {
            return base.Channel.GetAllSeasons();
        }
        
        public System.Threading.Tasks.Task<Tippspiel_Verwaltungsclient.ServiceReference1.Season[]> GetAllSeasonsAsync() {
            return base.Channel.GetAllSeasonsAsync();
        }
        
        public object RemoveSeason() {
            return base.Channel.RemoveSeason();
        }
        
        public System.Threading.Tasks.Task<object> RemoveSeasonAsync() {
            return base.Channel.RemoveSeasonAsync();
        }
    }
}