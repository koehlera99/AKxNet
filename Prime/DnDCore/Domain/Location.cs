using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DnD.Core.Domain
{
    public class Location : Object
    {
        public List<Building> Buildings { get; set; }
        public virtual Campaign Campaign { get; set; }
        public List<Npc> Npcs { get; set; }
    }
}
