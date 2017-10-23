using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.DomainModels
{
    public class Building : DndObject, IStructure
    {
        public List<Room> Rooms { get; set; }
    }
}
