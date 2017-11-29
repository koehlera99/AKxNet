using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace TCS.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    class ServerDuplexContract : IServerDuplexContract
    {

        IServerDuplexContractCallback callback = null;
        private readonly List<Client> _clients = new List<Client>();


        public ServerDuplexContract()
        {
            callback = OperationContext.Current.GetCallbackChannel<IServerDuplexContractCallback>();
        }

        public void SendMessage(string message)
        {
            callback.SendResponse("Message received.");
        }


        Guid IServerDuplexContract.Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IServerDuplexContractCallback>();
            var clientId = Guid.NewGuid();

            if (callback == null) return Guid.Empty;

            lock (_clients)
            {
                _clients.Add(new Client
                {
                    ClientId = clientId,
                    Callback = callback
                });
            }

            return clientId;
        }

        void IServerDuplexContract.Unsubscribe(Guid clientId)
        {
            lock (_clients)
            {
                if (_clients.Any(i => i.ClientId == clientId))
                {
                    _clients.Remove(_clients.First(i => i.ClientId == clientId));
                }
            }
        }

        void IServerDuplexContract.Broadcast(Guid clientId, string message)
        {
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (_clients)
                    {
                        var clientGuids = new List<Guid>();

                        foreach (var client in _clients)
                        {
                            try
                            {
                                // if the client isn't the one which raised the message
                                if (client.ClientId != clientId)
                                {
                                    client.Callback.SendResponse(message);
                                }
                            }
                            catch (Exception)
                            {
                                clientGuids.Add(client.ClientId);
                            }
                        }

                        foreach (var clientGuid in clientGuids)
                        {
                            _clients.Remove(_clients.First(i => i.ClientId == clientGuid));
                        }
                    }
                }
            );
        }
    }

    public class Client
    {
        public Guid ClientId { get; set; }

        public IServerDuplexContractCallback Callback { get; set; }
    }

    public class NotificationServiceHandler
    {
        #region Module Level Variables

        private Guid _clientId;
        private ServerDuplexContract _notificationServiceClient;
        private NotificationServiceCallback _notificationServiceCallback;


        #endregion

        #region Constructor

        public NotificationServiceHandler()
        {
            _notificationServiceCallback = new NotificationServiceCallback();
            _notificationServiceCallback.ClientNotified += NotificationServiceCallback_ClientNotified;
            _notificationServiceClient = new ServerDuplexContract();
            
            //TODO: Fix
            //_clientId = _notificationServiceClient.Subscribe();
        }

        #endregion

        #region Public Methods

        public void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            //TODO: Fix
            //_notificationServiceClient.Broadcast(_clientId, message);
        }

        #endregion

        #region Events

        public delegate void MessageRecievedDelegate(string message);
        public event MessageRecievedDelegate MessageRecieved;

        private void NotificationServiceCallback_ClientNotified(object sender, ClientNotifiedEventArgs e)
        {
            try
            {
                if (MessageRecieved != null)
                    MessageRecieved.Invoke(e.Message);
            }
            catch (Exception)
            {
                // TODO: Handle exception.
            }
        }



        public class NotificationServiceCallback : IServerDuplexContractCallback
        {
            public delegate void ClientNotifiedEventHandler(object sender, ClientNotifiedEventArgs e);

            public event ClientNotifiedEventHandler ClientNotified;

            /// <summary>
            /// Notifies the client of the message by raising an event.
            /// </summary>
            /// <param name="message">Message from the server.</param>
            void IServerDuplexContractCallback.SendResponse(string message)
            {
                if (ClientNotified != null)
                {
                    ClientNotified(this, new ClientNotifiedEventArgs(message));
                }
            }
        }

        public class ClientNotifiedEventArgs : EventArgs
        {
            private readonly string _message;

            public ClientNotifiedEventArgs(string message)
            {
                _message = message;
            }

            public string Message
            {
                get { return _message; }
            }
        }

        #endregion
    }
}
