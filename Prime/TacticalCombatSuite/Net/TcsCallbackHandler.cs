using System.Windows;
using System.Windows.Media;
using TCS.WPF;

namespace TCS.Net
{
    public class TcsServiceCallbackHandler 
    {
        //public void AddUnits(ClientData client)
        //{

        //}

        //public void RemoveUnit(UnitData unit)
        //{

        //}

        //public void AddClient(ClientData client)
        //{

        //}

        //public void RemoveClient(ClientData client)
        //{

        //}

        void SubscribeClientResponse(ClientData client)
        {
            FantasyBattle.BattleGrid.AddNewUnitSphere(client);
        }

        void UnsubscribeClientResponse(ClientData client)
        {
            FantasyBattle.BattleGrid.RemoveUnitSphere(client.Units[0]);
        }

        void AddUnitsResponse(ClientData client)
        {
            FantasyBattle.BattleGrid.AddNewUnitSphere(client);
        }

        void RemoveUnitResponse(UnitData unit)
        {
            FantasyBattle.BattleGrid.RemoveUnitSphere(unit);
        }

        void BroadcastMessageResponse(ClientData client, string message)
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w is MudInterface)
                {
                    ((MudInterface)w).PrintToScreen(client.ClientName + " says: " + message, Brushes.Yellow);
                }
            }
        }

        void BroadcastCommandResponse(Command command)
        {
            switch (command.CommandName.ToUpper())
            {
                case "MOVE":
                    Move(command);
                    break;
                default:
                    break;
            }
        }

        public static void Move(Command command)
        {
            FantasyBattle.BattleGrid.MoveUnitSphere(command.Unit);
        }
    }
}
