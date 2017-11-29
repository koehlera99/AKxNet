using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG
{
    public abstract class Object : IEquatable<Object>
    {
        public int ID;
        public Guid GID;
        //public RPGObjectType PrimeType { get; }

        public Object()
        {
            GID = Guid.NewGuid();
        }

        //public Object(RPGObjectType primeType)
        //{
        //    GID = Guid.NewGuid();
        //    PrimeType = primeType;
        //}

        public override bool Equals(object obj)
        {
            return obj == null ? false : Equals(obj as Object);
        }

        public bool Equals(Object obj)
        {
            return obj == null ? false : ID.Equals(obj.ID);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }

    //public enum RPGObjectType
    //{
    //    Unit,
    //    Item,
    //    Room,
    //    World,
    //    Universe,
    //    Event,
    //    Ability,
    //    Property,
    //    Effect,
    //    Element
    //}


}
