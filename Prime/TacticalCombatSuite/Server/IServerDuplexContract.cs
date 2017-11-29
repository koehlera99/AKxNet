using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace TCS.Server
{
    [ServiceContract(Namespace = "http://akxnet.com", SessionMode = SessionMode.Required, CallbackContract = typeof(IServerDuplexContractCallback))]
    public interface IServerDuplexContract
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);

        [OperationContract]
        Guid Subscribe();

        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid clientId);

        [OperationContract]
        void Broadcast(Guid clientId, string message);
    }


    public interface IServerDuplexContractCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendResponse(string response);
    }

}
