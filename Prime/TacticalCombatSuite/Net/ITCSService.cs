using System.Collections.Generic;
using System.ServiceModel;

namespace TCS.Net
{
    [ServiceContract(Namespace = "http://akxnet.com", SessionMode = SessionMode.Required, CallbackContract = typeof(ITCSServiceCallback))]
    public interface ITCSService
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeClient(ClientData client);

        [OperationContract(IsOneWay = true)]
        void UnsubscribeClients(List<ClientData> clients);

        [OperationContract(IsOneWay = true)]
        void AddUnits(ClientData client, List<UnitData> units);

        [OperationContract(IsOneWay = true)]
        void RemoveUnit(UnitData unit);

        [OperationContract(IsOneWay = true)]
        void BroadcastMessage(ClientData client, string message);

        [OperationContract(IsOneWay = true)]
        void BroadcastCommand(Command command);
    }

    public interface ITCSServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SubscribeClientResponse(ClientData client);

        [OperationContract(IsOneWay = true)]
        void UnsubscribeClientResponse(ClientData client);

        [OperationContract(IsOneWay = true)]
        void AddUnitsResponse(ClientData client);

        [OperationContract(IsOneWay = true)]
        void RemoveUnitResponse(UnitData unit);

        [OperationContract(IsOneWay = true)]
        void BroadcastMessageResponse(ClientData client, string message);

        [OperationContract(IsOneWay = true)]
        void BroadcastCommandResponse(Command command);
    }
}
