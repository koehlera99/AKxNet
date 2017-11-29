using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace TCS.Server
{
    class ServerHost : IDisposable
    {
        
        private Uri baseAddress = new Uri("net.tcp://localhost:8090/Server");
        public Uri metaAddress { get; } = new Uri("http://localhost:8080/Server/Meta");


        private ServiceHost host;

        
        public ServerHost() {  }

        public void Start()
        {
            if (host != null && host.State == CommunicationState.Opened)
                host.Close();

            host = new ServiceHost(typeof(ServerDuplexContract));
            host.Description.Endpoints.Clear();

            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = metaAddress;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy12;
            host.Description.Behaviors.Add(smb);

            host.AddServiceEndpoint(typeof(IServerDuplexContract), new NetTcpBinding(), baseAddress);

            
            host.Open();
        }

        public void Stop()
        {
            if (host != null &&  host.State == CommunicationState.Opened)
                host.Close();
        }

        public EndpointAddress GetEndPointAddress()
        {
            return host.Description.Endpoints[0].Address;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    if (host.State == CommunicationState.Opened)
                        host.Close();

                disposedValue = true;
            }
        }

         ~ServerHost()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
