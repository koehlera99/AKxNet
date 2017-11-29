using System.ServiceModel;

namespace TCS.Net
{
    [ServiceContract(Namespace = "http://akxnet.com", SessionMode = SessionMode.Required, CallbackContract = typeof(ITCSServiceReferenceResponse))]
    public interface ITCSServiceReference
    {
        [OperationContract]
        ClientData SubscribeClient(ClientData client);

        [OperationContract(IsOneWay = true)]
        void UnsubscribeClient(ClientData client);

        [OperationContract]
        ClientData AddUnits(ClientData client);

        [OperationContract(IsOneWay = true)]
        void RemoveUnit(UnitData unit);

        [OperationContract(IsOneWay = true)]
        void BroadcastMessage(ClientData client, string message);

        [OperationContract(IsOneWay = true)]
        void BroadcastCommand(Command command);
    }

    public interface ITCSServiceReferenceResponse
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
        void BroadcastMessageResponse(ClientData client, string response);

        [OperationContract(IsOneWay = true)]
        void BroadcastCommandResponse(Command command);
    }
}



