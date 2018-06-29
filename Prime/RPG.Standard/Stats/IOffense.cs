using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Stats
{
    interface IOffense
    {
        int Melee { get; }
        int Ranged { get; }
        int Magic { get; }
    }
}
