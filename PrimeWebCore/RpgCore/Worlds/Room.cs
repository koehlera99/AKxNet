using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


using TCS.RPG.Units;
using TCS.RPG.Items;
using TCS.RPG.Effects;

namespace TCS.RPG.Worlds
{
    class Room : RPGObject
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<Event> Events { get; set; } = new List<Event>();

        private Section[,] Sections;

        public Room() : base(RPGObjectType.Room)
        {
            Sections = new Section[10, 10];
        }

        public Room(int sections) : base(RPGObjectType.Room)
        {
            Sections = new Section[sections, sections];
        }

        public Room(int sectionsX, int sectionsY) : base(RPGObjectType.Room)
        {
            Sections = new Section[sectionsX, sectionsY];
        }

        public Section GetSection(int x, int y)
        {
            return Sections[x, y];
        }

        public Section GetSection(Point point)
        {
            return Sections[point.X, point.Y];
        }

        public void SetSection(int x, int y, Section section)
        {
            Sections[x, y] = section;
        }

        public void SetSection(Point point, Section section)
        {
            Sections[point.X, point.Y] = section;
        }
    }
}
