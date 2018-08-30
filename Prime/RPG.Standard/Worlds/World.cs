using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG.Standard.Effects;

namespace RPG.Standard.Worlds
{
    class World : Object
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Event> Events { get; set; } = new List<Event>();

        public World() { }
    }
}
