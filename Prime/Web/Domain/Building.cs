using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core;

namespace Web.Domain
{
    public class Building : DndObject, IStructure
    {
        public List<Room> Rooms { get; set; }
    }
}
