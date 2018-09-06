using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Standard.Base.Stats;
using RPG.Standard.Base;

namespace RPG.Standard.Stats
{
    public interface IUnitStats : IPrimaryStats, IOffense, IDefense
    {
        int Power { get; }
        int Mind { get; }
        int Energy { get; }
    }
}
