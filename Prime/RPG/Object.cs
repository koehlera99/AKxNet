using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core
{
    public abstract class Object : IEquatable<Object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Object() { }
        protected Object(int id)
        {
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

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
