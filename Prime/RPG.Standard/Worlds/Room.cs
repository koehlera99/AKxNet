using System.Collections.Generic;
using System.Drawing;
using RPG.Standard.Effects;
using RPG.Standard.Items;
using RPG.Standard.Units;
using System.Linq;

namespace RPG.Standard.Worlds
{
    class Room : Object
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Section> Sections { get; set; } = new List<Section>();

        //private Section[,] Sections;

        public Room()
        {
            //Sections = new Section[10, 10];
        }

        public Room(int sections)
        {
            //Sections = new Section[sections, sections];
        }

        public Room(int sectionsX, int sectionsY)
        {
            //Sections = new Section[sectionsX, sectionsY];
        }

        public Section GetSection(int x, int y)
        {
            return Sections.FirstOrDefault(s => s.Location.X == x && s.Location.Y == y);
        }

        public Section GetSection(Point point)
        {
            return Sections.FirstOrDefault(s => s.Location.X == point.X && s.Location.Y == point.Y);
        }

        public void SetSection(int x, int y, Section section)
        {
            //Sections[x, y] = section;
        }

        public void SetSection(Point point, Section section)
        {
            //Sections[point.X, point.Y] = section;
        }
    }
}
