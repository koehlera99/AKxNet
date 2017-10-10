using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public abstract class DndObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected DndObject() { }
        protected DndObject(int id)
        {
            id = Id;
        }

        protected DndObject(string name)
        {
            Name = name;
        }

        protected DndObject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected DndObject(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public  override string ToString()
        {
            return Name;
        }
    }
}
