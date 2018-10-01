using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace RPG.Net
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class RpgService : IRpgService
    {
        public static List<ClientData> ListOfClients;

        public RpgService()
        {
            ListOfClients = new List<ClientData>();
        }

        public void SubscribeClient(ClientData client)
        {
            //ClientData client = new ClientData();
            //client.ClientName = clientName;
            //client.ClientIDString = Guid.NewGuid();
            client.Callback = OperationContext.Current.GetCallbackChannel<IRpgServiceCallback>();

            //If no callback channel, return empty GUID
            if (client.Callback != null)
            {
                lock (ListOfClients)
                {
                    ListOfClients.Add(client);
                }

                try
                {
                    ThreadPool.QueueUserWorkItem
                    (
                        delegate
                        {
                            lock (ListOfClients)
                            {
                                //If any fail, create list of faling GUID's to remove from List
                                var clientsNotFound = new List<ClientData>();

                                foreach (var c in ListOfClients)
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

        public void AddUnits(ClientData client, List<UnitData> units)
        {
            ClientData clientCopy = (ListOfClients.First(i => i.ClientID == client.ClientID));

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
                            lock (ListOfClients)
                            {
                                //If any fail, create list of faling GUID's to remove from List
                                var clientsNotFound = new List<ClientData>();

                                //Inform all clients of units added
                                foreach (var c in ListOfClients)
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

        public void UnsubscribeClients(List<ClientData> clients)
        {
            foreach (var c in clients)
            {
                lock (ListOfClients)
                {
                    //Remove c from List of connected clients
                    if (ListOfClients.Any(i => i.ClientID == c.ClientID))
                    {
                        ListOfClients.Remove(ListOfClients.First(i => i.ClientID == c.ClientID));
                    }
                }
            }

            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Inform all clients of units added
                            foreach (var c in ListOfClients)
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

        public void RemoveUnit(UnitData unit)
        {
            ClientData clientCopy = (ListOfClients.First(i => i.ClientID == unit.ClientID));
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
                            lock (ListOfClients)
                            {
                                //If any fail, create list of faling GUID's to remove from List
                                var clientsNotFound = new List<ClientData>();

                                //Inform all clients of units removed
                                foreach (var c in ListOfClients)
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

        public void BroadcastMessage(ClientData client, string message)
        {
            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Send message to all clients
                            foreach (var c in ListOfClients)
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

        public void BroadcastCommand(CommandData command)
        {
            try
            {
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (ListOfClients)
                        {
                            //If any fail, create list of faling GUID's to remove from List
                            var clientsNotFound = new List<ClientData>();

                            //Send command to all clients
                            foreach (var c in ListOfClients)
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
