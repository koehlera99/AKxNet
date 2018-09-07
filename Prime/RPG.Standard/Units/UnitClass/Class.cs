using RPG.Standard.Base.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Units.UnitClass
{
    class ClassBase
    {
        public Primary PrimaryStat;
        public Primary SecondaryStat;

        public short HitDice { get; set; }
    }
}
