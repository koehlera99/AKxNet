using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicAttackObject
    {
        public int AttackRoll { get; }
        public int Damage { get; set; }

        public string AttackType { get; set; }
        public string AttackTarget { get; set; }
        public string DamageType { get; set; }

        public BasicUnit Defender { get; }
        public BasicUnit Attacker { get; }

        public BasicAttackObject(int attackRoll, int damage, BasicUnit defender, BasicUnit attacker, string attackType = "", string attackTarget = "", string damageType = "")
        {
            AttackRoll = AttackRoll;
            Damage = damage;
            AttackType = attackType;
            AttackTarget = attackTarget;
            DamageType = damageType;

            Defender = defender;
            Attacker = attacker;
        }
    }
}
