//using System;
//using System.Collections.Generic;
//using System.ServiceModel;
//using System.Windows;

//namespace TCS.Net
//{
//    public static class NetManager
//    {
//        public static InstanceContext tcsServiceCallbackHandler = new InstanceContext(new TcsServiceCallbackHandler());
//        public static TCSServiceClient Client;

//        public static List<ClientData> PlayersOnline { get; set; } = new List<ClientData>();

//        //public static Guid ClientID { get; private set; }
//        //public static string ClientName { get; private set; }

//        private static string baseUriAddress = "net.tcp://localhost:22222/TCSService";

//        public static bool JoinServer(string uriAddress, string name)
//        {
//            try
//            {
//                Players.Client.Units[0].UnitName = name;
//                Client = new TCSServiceClient(tcsServiceCallbackHandler);
//                Uri uri = new Uri(uriAddress);
//                //Uri uri = new Uri(baseUriAddress);

//                EndpointAddress address = new EndpointAddress(uri);

//                Client.Endpoint.Address = address;
//                Client.SubscribeClient(Players.Client);

//                Players.AddNew(Players.Client.Units[0].UnitID);

//                return true;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//                return false;
//            }
//        }

//        public static void UnSubscribe()
//        {
//            Client.UnsubscribeClients(new List<ClientData> { Players.Client });
//        }
//    }
//}



