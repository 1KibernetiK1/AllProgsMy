using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public interface IClientCallback
    {
        [OperationContract]
        void SendAnswer(string msg);
    }

    [ServiceContract(CallbackContract =typeof(IClientCallback))]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string msg);

        [OperationContract]
        void UserJoin(string name);

        [OperationContract]
        void UserLeave(string name);
    }
}
