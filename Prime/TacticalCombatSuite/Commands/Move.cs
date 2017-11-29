using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.RPG.Units;
using TCS.RPG.Items;

namespace TCS.Commands
{ 
    partial class CommandOld
    {
        public static partial class Basic
        {
            public static void Move(Direction direction, int spaces)
            {
                int x, y;

                switch (direction)
                {
                    case Direction.North:
                        y = 1;
                        break;
                    case Direction.NorthEast:
                        x = 1;
                        y = 1;
                        break;
                    case Direction.East:
                        x = 1;
                        break;
                    case Direction.SouthEast:
                        y = -1;
                        x = 1;
                        break;
                    case Direction.South:
                        y = -1;
                        break;
                    case Direction.SouthWest:
                        y = -1;
                        x = -1;
                        break;
                    case Direction.West:
                        x = -1;
                        break;
                    case Direction.NorthWest:
                        x = -1;
                        y = -1;
                        break;
                    default:
                        x = 0;
                        y = 0;
                        break;
                }
            }
        }
    }
}