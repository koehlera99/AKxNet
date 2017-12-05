using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.RPG.Effects;

namespace TCS.RPG.Worlds
{
    class World : Object
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Event> Events { get; set; } = new List<Event>();

        public World() { }
    }
}
