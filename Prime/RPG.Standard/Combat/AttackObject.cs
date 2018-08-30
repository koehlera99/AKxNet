using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class AttackObject
    {
        public string AttackType { get; set; }
        public int AttackRoll { get; set; }

        public AttackObject(IUnit attackingUnit, IEnumerable<IUnit> defendingUnits, IEnumerable<IAttack> attacks)
        {
            AttackingUnit = attackingUnit;
            DefendingUnits = defendingUnits;
            Attacks = attacks;
        }

        IUnit AttackingUnit { get; }
        IEnumerable<IUnit> DefendingUnits { get; }
        IEnumerable<IAttack> Attacks { get; }
    }
}
