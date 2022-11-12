using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatServices
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string senderUsername, string message);
    }

    [ServiceContract]
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageSend(string message);
    }
}

