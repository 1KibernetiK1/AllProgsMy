﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClient.Chat {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Chat.IChatService", CallbackContract=typeof(ChatClient.Chat.IChatServiceCallback))]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendMessage", ReplyAction="http://tempuri.org/IChatService/SendMessageResponse")]
        void SendMessage(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendMessage", ReplyAction="http://tempuri.org/IChatService/SendMessageResponse")]
        System.Threading.Tasks.Task SendMessageAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/UserJoin", ReplyAction="http://tempuri.org/IChatService/UserJoinResponse")]
        void UserJoin(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/UserJoin", ReplyAction="http://tempuri.org/IChatService/UserJoinResponse")]
        System.Threading.Tasks.Task UserJoinAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/UserLeave", ReplyAction="http://tempuri.org/IChatService/UserLeaveResponse")]
        void UserLeave(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/UserLeave", ReplyAction="http://tempuri.org/IChatService/UserLeaveResponse")]
        System.Threading.Tasks.Task UserLeaveAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendAnswer", ReplyAction="http://tempuri.org/IChatService/SendAnswerResponse")]
        void SendAnswer(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : ChatClient.Chat.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.DuplexClientBase<ChatClient.Chat.IChatService>, ChatClient.Chat.IChatService {
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendMessage(string msg) {
            base.Channel.SendMessage(msg);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string msg) {
            return base.Channel.SendMessageAsync(msg);
        }
        
        public void UserJoin(string name) {
            base.Channel.UserJoin(name);
        }
        
        public System.Threading.Tasks.Task UserJoinAsync(string name) {
            return base.Channel.UserJoinAsync(name);
        }
        
        public void UserLeave(string name) {
            base.Channel.UserLeave(name);
        }
        
        public System.Threading.Tasks.Task UserLeaveAsync(string name) {
            return base.Channel.UserLeaveAsync(name);
        }
    }
}
