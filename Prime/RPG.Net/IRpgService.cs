using System.Collections.Generic;
using System.ServiceModel;

namespace RPG.Net
{
    [ServiceContract(Namespace = "http://akxnet.com", SessionMode = SessionMode.Required, CallbackContract = typeof(IRpgServiceCallback))]
    public interface IRpgService
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
        void BroadcastCommand(CommandData command);
    }

    public interface IRpgServiceCallback
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
        void BroadcastCommandResponse(CommandData command);
    }
}
