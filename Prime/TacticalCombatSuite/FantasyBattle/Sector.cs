using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.FantasyBattle
{
    class Sector
    {
        public List<Room> Rooms { get; set; }

        public Sector()
        {
            Rooms = new List<Room>();
        }
    }
}
