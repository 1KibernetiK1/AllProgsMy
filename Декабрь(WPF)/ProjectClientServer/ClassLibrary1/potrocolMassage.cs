using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum MessageType
    {
        ServiceMessage,
        RegularMessage, 
    }

    public enum RegularMessageType
    {
        PublicMessage,
        PrivateMessage
    }

    public enum ServiceMessageType
    {
        UserLoginMessage,
        UserJoinMessage,
        UserDisconnectMessage
    }

    public class potrocolMassageHeader
    {
        public MessageType Type { get; set; }

        public MessageBody Body { get; set; }
    }

    public class MessageBody
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Message { get; set; }
    }

    public class ServiceMessageBody : MessageBody
    {
        public ServiceMessageType serviceMessageType { get; set; }
    }

    public class RegularMessageBody : MessageBody
    {
        public ServiceMessageType PrivACY { get; set; }
    }
}
