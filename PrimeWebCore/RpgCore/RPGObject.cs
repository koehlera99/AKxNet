using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG
{
    public abstract class RPGObject : IEquatable<RPGObject>
    {
        public int ID;
        public Guid GID;
        public RPGObjectType PrimeType { get; }

        public RPGObject()
        {
            GID = Guid.NewGuid();
        }

        public RPGObject(RPGObjectType primeType)
        {
            GID = Guid.NewGuid();
            PrimeType = primeType;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RPGObject primeObject = obj as RPGObject;
            if (primeObject == null) return false;
            else return Equals(primeObject);
        }

        public bool Equals(RPGObject rpgObject)
        {
            if (rpgObject == null) return false;
            return (this.ID.Equals(rpgObject.ID) && this.PrimeType == rpgObject.PrimeType);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }

    public enum RPGObjectType
    {
        Unit,
        Item,
        Room,
        World,
        Universe,
        Event,
        Ability,
        Property,
        Effect,
        Element
    }


}
