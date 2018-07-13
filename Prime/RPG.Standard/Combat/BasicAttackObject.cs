using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Items.Offense;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicAttackObject
    {
        public AttackRoll AttackRoll { get; set; }
        public int Damage { get; set; }

        public string AttackType { get; set; }
        public string AttackTarget { get; set; }
        public string DamageType { get; set; }

        public IWeapon Weapon { get; set; }
        public BasicUnit Attacker { get; }
        public List<BasicUnit> Defenders { get; } 

        public BasicAttackObject(AttackRoll attackRoll, IWeapon weapon, BasicUnit attacker, List<BasicUnit> defenders, string attackType = "", string attackTarget = "", string damageType = "")
        {
            AttackRoll = attackRoll;
            Weapon = weapon;
            Damage = weapon.DamageAmount;
            Attacker = attacker;
            Defenders = defenders;
            AttackType = attackType;
            AttackTarget = attackTarget;
            DamageType = damageType;
        }
    }
}
