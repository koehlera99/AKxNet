using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicCombatResolver
    {
        private BasicAttackObject Attack;

        public BasicCombatResolver(BasicAttackObject basicAttackObject)
        {
            Attack = basicAttackObject;
        }

        public int? ResolveAttack()
        {
            var defense = Attack.Defender.DefendAgainstAttack(Attack);

            if (Attack.AttackRoll >= defense.DefenseValue)
            {
                int damage = Attack.Damage - defense.DamageResistance;
                Attack.Defender.CurrentHP -= damage;

                return damage;
            }
            else
            {
                return null;
            }
        }
    }
}
