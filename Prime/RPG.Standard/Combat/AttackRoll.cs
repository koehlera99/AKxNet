using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class AttackRoll
    {
        public bool IsAutoHit { get; private set; }
        public int BasicAttackValue { get; }
        public int BasicAttackRoll { get; private set; }
        public int FullAttackRoll => BasicAttackRoll + BasicAttackValue;

        public AttackRoll(BasicUnit unit)
        {
            BasicAttackValue = unit.BasicDefenseValue;

            RollBasicAttack();
        }

        public void RollBasicAttack()
        {
            BasicAttackRoll = Roll.d100;
            IsAutoHit = BasicAttackRoll >= 95;
        }
    }
}
