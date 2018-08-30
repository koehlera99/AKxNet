using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class BasicDefenseObject
    {
        public int DamageResistance { get; set; }

        public DefenseRoll BasicDefenseRoll { get; set; }

        public BasicDefenseObject(BasicUnit unit)
        {
            BasicDefenseRoll = new DefenseRoll(unit);
            DamageResistance = unit.DamageResistanceTest;
        }
    }
}
