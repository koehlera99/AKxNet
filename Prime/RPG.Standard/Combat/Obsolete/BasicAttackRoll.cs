using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    //public class BasicAttackRoll
    //{
    //    public bool IsAutoHit { get; private set; }
    //    public int BasicAttackValue { get; }
    //    public int BasicAttackRollValue { get; private set; }
    //    public int FullAttackRoll => BasicAttackRollValue + BasicAttackValue;

    //    public BasicAttackRoll(Unit unit)
    //    {
    //        BasicAttackValue = unit.Stats.ArmorClass.Value;

    //        RollBasicAttack();
    //    }

    //    public void RollBasicAttack()
    //    {
    //        BasicAttackRollValue = Roll.d100;
    //        IsAutoHit = BasicAttackRollValue >= 95;
    //    }
    //}
}
