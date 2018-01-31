using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core.Stats
{
    [Obsolete("Included in IUnitStat")]
    class BaseStats
    {
        public int Power { get; set; }
        public int Mind { get; set; }
        public int Energy { get; set; }
    }
}
