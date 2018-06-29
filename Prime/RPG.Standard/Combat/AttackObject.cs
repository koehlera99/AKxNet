using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class AttackObject
    {
        public string AttackType { get; set; }
        public int AttackRoll { get; set; }
        public AttackObject(IUnit attackingUnit, IList<IUnit> defendingUnits, IList<IAttack> attacks)
        {
            AttackingUnit = attackingUnit;
            DefendingUnits = defendingUnits;
            Attacks = attacks;
        }

        IUnit AttackingUnit { get; }
        IList<IUnit> DefendingUnits { get; }
        IList<IAttack> Attacks { get; }
    }
}
