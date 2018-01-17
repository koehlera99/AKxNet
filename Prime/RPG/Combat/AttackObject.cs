using System;
using System.Collections.Generic;
using System.Text;
using RPG.Core.Units;

namespace RPG.Core.Combat
{
    class AttackObject
    {
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
