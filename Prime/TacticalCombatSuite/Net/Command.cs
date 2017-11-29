using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TCS.Net
{
    [DataContract]
    public class Command
    {
        [DataMember]
        public ClientData Sender { get; set; }

        [DataMember]
        public UnitData Unit { get; set; }

        [DataMember]
        public string CommandName { get; set; }

        [DataMember]
        public List<string> Parameters { get; set; }
    }
}
