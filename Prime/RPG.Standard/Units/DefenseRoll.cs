using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;

namespace RPG.Standard.Units
{
    class DefenseRoll
    {
        public int BasicDefenseValue { get; }
        public int BasicDefenseRoll { get; private set; }
        public int FullDefenseRoll => BasicDefenseRoll + BasicDefenseValue;

        public DefenseRoll(int basicDefenseValue)
        {
            BasicDefenseValue = basicDefenseValue;

            RollBasicDefense();
        }

        public void RollBasicDefense()
        {
            BasicDefenseRoll = Roll.D100();
        }
    }
}
