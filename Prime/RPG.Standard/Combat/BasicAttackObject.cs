using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Combat
{
    class BasicAttackObject
    {
        public int AttackRoll { get; set; }
        public int Damage { get; set; }

        public string AttackType { get; set; }
        public string AttackTarget { get; set; }
        public string DamageType { get; set; }

        public BasicAttackObject(int attackRoll, int damage, string attackType = "", string attackTarget = "", string damageType = "")
        {
            AttackRoll = AttackRoll;
            Damage = damage;
            AttackType = attackType;
            AttackTarget = attackTarget;
            DamageType = damageType;
        }
    }
}
