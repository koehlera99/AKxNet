using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DnD.Core.Domain
{
    public class Npc : Object
    {
        public virtual Location Location { get; set; }
    }
}
