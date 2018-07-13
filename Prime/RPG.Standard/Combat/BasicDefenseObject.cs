using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicDefenseObject
    {
        public int DamageResistance { get; set; }

        public DefenseRoll BasicDefenseRoll { get; set; }

        public BasicDefenseObject(int defenseValue, int damageResistance = 0)
        {
            BasicDefenseRoll = new DefenseRoll(defenseValue);
            DamageResistance = damageResistance;
        }
    }
}
