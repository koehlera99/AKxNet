using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.RPG.Effects;

namespace TCS.RPG.Worlds
{
    class Universe : Object
    {
        public List<World> Worlds { get; set; } = new List<World>();
        public List<Event> Events { get; set; } = new List<Event>();

        public Universe() { }
    }
}
