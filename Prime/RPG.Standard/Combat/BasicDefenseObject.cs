using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Combat
{
    class BasicDefenseObject
    {
        public int DefenseValue { get; set; }
        public int DamageResistance { get; set; }

        public BasicDefenseObject(int defenseValue, int damageResistance = 0)
        {
            DefenseValue = defenseValue;
            DamageResistance = damageResistance;
        }
    }
}
