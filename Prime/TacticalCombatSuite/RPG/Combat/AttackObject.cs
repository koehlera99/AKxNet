using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Combat
{
    class AttackObject : IAttackObject
    {
        public AttackObject(AttackType attackType, int attackRoll, int damageRoll)
        {
            AttackType = attackType;
            AttackRoll = attackRoll;
            DamageRoll = damageRoll;

        }

        public AttackType AttackType { get; }
        public int AttackRoll { get; }
        public int DamageRoll { get; }
    }

    enum AttackType
    {
        Melee,
        Ranged,
        Spell
    }

    interface IAttackObject
    {
        AttackType AttackType { get; }
        int AttackRoll { get; }
        int DamageRoll { get; }
    }
}
