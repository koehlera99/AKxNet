using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Stats
{
    interface IPrimaryStats
    {
        int Strength { get; }
        int Dexterity { get; }
        int Constitution { get; }
        int Intelligence { get; }
        int Wisdom { get; }
        int Charisma { get; }
    }
}
