using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core;


namespace Web.Domain
{
    public class Npc : DndObject
    {
        public virtual Location Location { get; set; }
    }
}
