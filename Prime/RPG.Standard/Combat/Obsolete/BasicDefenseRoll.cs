using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Tools;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    //public class BasicDefenseRoll
    //{
    //    public bool IsAutoMiss { get; private set; }
    //    public int BasicDefenseValue { get; }
    //    public int BasicDefenseRollValue { get; private set; }
    //    public int FullDefenseRoll => BasicDefenseRollValue + BasicDefenseValue;

    //    public BasicDefenseRoll(Unit unit)
    //    {
    //        BasicDefenseValue = unit.Stats.ArmorClass.Value;

    //        RollBasicDefense();
    //    }

    //    public void RollBasicDefense()
    //    {
    //        BasicDefenseRollValue = Roll.d100;
    //        IsAutoMiss = BasicDefenseRollValue >= 95;
    //    }
    //}
}
