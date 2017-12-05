using System.Collections.Generic;


namespace DnD.Core.Domain
{
    public class Building : Object, IStructure
    {
        public List<Room> Rooms { get; set; }
    }
}
