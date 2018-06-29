using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Stats
{
    interface IUnitStats : IPrimaryStats, IOffense, IDefense
    {
        int Power { get; }
        int Mind { get; }
        int Energy { get; }
    }
}
