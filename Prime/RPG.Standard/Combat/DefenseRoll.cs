using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class DefenseRoll
    {
        public bool IsAutoMiss { get; private set; }
        public int BasicDefenseValue { get; }
        public int BasicDefenseRoll { get; private set; }
        public int FullDefenseRoll => BasicDefenseRoll + BasicDefenseValue;

        public DefenseRoll(BasicUnit unit)
        {
            BasicDefenseValue = unit.BasicDefenseValue;

            RollBasicDefense();
        }

        public void RollBasicDefense()
        {
            BasicDefenseRoll = Roll.d100;
            IsAutoMiss = BasicDefenseRoll >= 95;
        }
    }
}
