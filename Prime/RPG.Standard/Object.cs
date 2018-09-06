using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard
{
    public abstract class Object : IEquatable<Object>
    {
        public Guid Guid { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Object()
        {
            Guid = new Guid();
        }

        protected Object(int id)
        {
            Guid = new Guid();
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Object);
        }

        public bool Equals(Object obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }

        public static bool operator== (Object obj, Object obj2)
        {
            return obj != null && obj2 != null && obj.Id.Equals(obj2.Id);
        }

        public static bool operator !=(Object obj, Object obj2)
        {
            return obj == null || obj2 == null || !obj.Id.Equals(obj2.Id);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
