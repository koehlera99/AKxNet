using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.FantasyBattle
{
    class Room
    {
        //Coordinate array of room sections
        public RoomSection[,] Sections { get; set; }

        public readonly int Height;
        public readonly int Width;

        public Room()
        {
            Height = 20;
            Width = 20;

            CreateRoom();
        }

        public Room(int width, int height)
        {
            Height = height;
            Width = width;

            CreateRoom();
        }

        /// <summary>
        /// Creates a new when first created based on height and width
        /// </summary>
        private void CreateRoom()
        {
            Sections = new RoomSection[Height, Width];

            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    Sections[x, y] = new RoomSection(x, y);
                }
            }
        }
    }


    //public List<RoomSection> SectionsOld { get; set; }
    //SectionsOld = new List<RoomSection>();
    //SectionsOld = new List<RoomSection>();

    //for(int x = 0; x < height; x++)
    //{
    //    for(int y = 0; y < width; y++)
    //    {
    //        SectionsOld.Add(new FantasyBattle.RoomSection(x, y));
    //    }
    //}
}
