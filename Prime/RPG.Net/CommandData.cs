using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Net
{
    [DataContract]
    public class CommandData
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
