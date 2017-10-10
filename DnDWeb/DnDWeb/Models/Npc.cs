using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public class Npc : DndObject
    {
        public virtual Location Location { get; set; }
    }
}
