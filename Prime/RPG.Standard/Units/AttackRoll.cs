using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;

namespace RPG.Standard.Units
{
    class AttackRoll
    {
        public bool IsAutoHit { get; private set; }
        public int BasicAttackValue { get; }
        public int BasicAttackRoll { get; private set; }
        public int FullAttackRoll => BasicAttackRoll + BasicAttackValue;

        public AttackRoll(int basicAttackValue)
        {
            BasicAttackValue = basicAttackValue;

            RollBasicAttack();
        }

        public void RollBasicAttack()
        {
            BasicAttackRoll = Roll.D100();
            IsAutoHit = BasicAttackRoll >= 95;
        }
    }
}
