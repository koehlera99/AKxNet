using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace TCS.Net
{
    //public class Client
    //{
    //    public UnitData Unit { get; set; }
    //    //public Guid ClientId { get; set; }
    //    //public string ClientName { get; set; }
    //    public ITCSServiceResponse Callback { get; set; }
    //}

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public partial class TCSService : ITCSService
    {
        public TCSService()
        {
            Main.ListOfClients = new List<ClientData>();
        }
        /// <summary>
        /// Interface Implementations
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        void ITCSService.SubscribeClient(ClientData client)
            { SubscribeClient(client); }

        void ITCSService.AddUnits(ClientData client, List<UnitData> units)
            { AddUnits(client, units); }

        void ITCSService.UnsubscribeClients(List<ClientData> clients)
            { UnsubscribeClients(clients); }

        void ITCSService.RemoveUnit(UnitData unit)
            { RemoveUnit(unit); }

        void ITCSService.BroadcastMessage(ClientData client, string message)
            { BroadcastMessage(client, message); }

        void ITCSService.BroadcastCommand(Command command)
            { BroadcastCommand(command); }

        /// <summary>
        /// Subscribe to Server
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private void SubscribeClient(ClientData client)
        {
            //ClientData client = new ClientData();
            //client.ClientName = clientName;
            //client.ClientIDString = Guid.NewGuid();
            client.Callback = OperationContext.Current.GetCallbackChannel<ITCSServiceCallback>();

            //If no callback channel, return empty GUID
            if (client.Callback != null)
            {
                lock (Main.ListOfClients)
                {
                    Main.ListOfClients.Add(client);
                }

                try
                {
                    ThreadPool.QueueUserWorkItem
                    (
                        delegate
                        {
                            lock (Main.ListOfClients)
                            {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                                foreach (var c in Main.ListOfClients)
                                {
                                    try
                                    {
                                    c.Callback.SubscribeClientResponse(client);
                                }
                                    catch (Exception)
                                    {
                                    //If error, add GUID to list of clients to remove from list
                                    clientsNotFound.Add(c);
                                    }
                                }

                            //Remove each failed c from list
                            UnsubscribeClients(clientsNotFound);
                            }
                        }
                    );
                }

                catch { }
            }
        }

        /// <summary>
        /// Unsubscribe from server
        /// </summary>
        /// <param name="clients"></param>
        private void UnsubscribeClients(List<ClientData> clients)
        {
            foreach (var c in clients)
            {
                lock (Main.ListOfClients)
                {
                    //Remove c from List of connected clients
                    if (Main.ListOfClients.Any(i => i.ClientID == c.ClientID))
                    {
                        Main.ListOfClients.Remove(Main.ListOfClients.First(i => i.ClientID == c.ClientID));
                    }
                }
            }

            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (Main.ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Inform all clients of units added
                            foreach (var c in Main.ListOfClients)
                            {
                                try
                                {
                                    c.Callback.UnsubscribeClientResponse(c);
                                }
                                catch (Exception)
                                {
                                    //If error, add GUID to list of clients to remove from list
                                    clientsNotFound.Add(c);
                                }
                            }

                            //Remove each failed c from list
                            UnsubscribeClients(clientsNotFound);
                        }
                    }
                );
            }

            catch { }
        }

        /// <summary>
        /// Add units to clientCopy
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private void AddUnits(ClientData client, List<UnitData> units)
        {
            ClientData clientCopy = (Main.ListOfClients.First(i => i.ClientID == client.ClientID));

            if (clientCopy != null)
            {
                if (clientCopy.Units == null)
                    clientCopy.Units = new List<UnitData>();

                foreach (var u in units)
                    u.UnitID = Guid.NewGuid();

                clientCopy.Units.AddRange(units);

                try
                {
                    ThreadPool.QueueUserWorkItem
                    (
                        delegate
                        {
                            lock (Main.ListOfClients)
                            {
                                //If any fail, create list of faling GUID's to remove from List
                                var clientsNotFound = new List<ClientData>();

                                //Inform all clients of units added
                                foreach (var c in Main.ListOfClients)
                                {
                                    try
                                    {
                                        c.Callback.AddUnitsResponse(clientCopy);
                                    }
                                    catch (Exception)
                                    {
                                        //If error, add GUID to list of clients to remove from list
                                        clientsNotFound.Add(c);
                                    }
                                }

                                //Remove each failed c from list
                                UnsubscribeClients(clientsNotFound);
                            }
                        }
                    );
                }

                catch { }
            }
        }

        /// <summary>
        /// Remove Units from clientCopy
        /// </summary>
        /// <param name="unit"></param>
        private void RemoveUnit(UnitData unit)
        {

            ClientData clientCopy = (Main.ListOfClients.First(i => i.ClientID == unit.ClientID));
            //ClientData clientCopy = (Main.ListOfClients.First(i => i.ClientID == unit.ClientID));

            if (clientCopy != null)
            {
                //Remove unit from client
                clientCopy.Units.RemoveAll(g => g.UnitID == unit.UnitID);

                ////Remove each selected unit from the clientCopy
                //foreach (var u in units)
                //{

                //}

                try
                {
                    ThreadPool.QueueUserWorkItem
                    (
                        delegate
                        {
                            lock (Main.ListOfClients)
                            {
                                //If any fail, create list of faling GUID's to remove from List
                                var clientsNotFound = new List<ClientData>();

                                //Inform all clients of units removed
                                foreach (var c in Main.ListOfClients)
                                {
                                    try
                                    {
                                        c.Callback.RemoveUnitResponse(unit);
                                    }
                                    catch (Exception)
                                    {
                                        //If error, add GUID to list of clients to remove from list
                                        clientsNotFound.Add(c);
                                    }
                                }

                                //Remove each failed c from list
                                UnsubscribeClients(clientsNotFound);
                            }
                        }
                    );
                }

                catch { }
            }
        }

        /// <summary>
        /// Broadcast Message to all clients
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private void BroadcastMessage(ClientData client, string message)
        {
            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (Main.ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Send message to all clients
                            foreach (var c in Main.ListOfClients)
                            {
                                try
                                {
                                    c.Callback.BroadcastMessageResponse(c, message);
                                }
                                catch (Exception)
                                {
                                    //If error, add GUID to list of clients to remove from list
                                    clientsNotFound.Add(c);
                                }
                            }

                            //Remove each failed c from list
                            UnsubscribeClients(clientsNotFound);
                        }
                    }
                );
            }

            catch { }
        }

        /// <summary>
        /// Broadcast command to all clients
        /// </summary>
        /// <param name="command"></param>
        private void BroadcastCommand(Command command)
        {
            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (Main.ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Send command to all clients
                            foreach (var c in Main.ListOfClients)
                            {
                                try
                                {
                                    //c.Callback.BroadcastCommandResponse(command);
                                }
                                catch (Exception)
                                {
                                    //If error, add GUID to list of clients to remove from list
                                    clientsNotFound.Add(c);
                                }
                            }

                            //Remove each failed c from list
                            UnsubscribeClients(clientsNotFound);
                        }
                    }
                );
            }

            catch { }
        }
    }
}
