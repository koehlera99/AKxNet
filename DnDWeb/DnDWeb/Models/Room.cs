using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public class Room : DndObject
    {
        public List<Furniture> Furniture { get; set; }
    }
}
