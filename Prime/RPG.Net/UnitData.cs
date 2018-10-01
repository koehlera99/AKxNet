using System;
using System.Runtime.Serialization;

namespace RPG.Net
{
    [DataContract]
    public class UnitData
    {
        [DataMember]
        public Guid ClientID { get; set; }

        [DataMember]
        public Guid UnitID { get; set; }

        [DataMember]
        public string UnitName { get; set; }

        [DataMember]
        public int HitPoints { get; set; }

        [DataMember]
        public int Power { get; set; }

        [DataMember]
        public int Magic { get; set; }

        [DataMember]
        public int Energy { get; set; }

        [DataMember]
        public UnitLocation Location { get; set; }
    }

    [DataContract]
    public class UnitLocation
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }

        [DataMember]
        public int Z { get; set; }
    }
}
