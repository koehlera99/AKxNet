using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TCS.Net
{
    [DataContract]
    public class ClientData
    {
        [DataMember]
        public Guid ClientID { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public List<UnitData> Units { get; set; }

        public ITCSServiceCallback Callback { get; set; }
    }

}
