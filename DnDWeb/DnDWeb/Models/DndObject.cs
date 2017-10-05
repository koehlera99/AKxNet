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

        public DndObject() { }
        public DndObject(int id)
        {
            id = Id;
        }

        public DndObject(string name)
        {
            Name = name;
        }

        public DndObject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public DndObject(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
