using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicCombatResolver
    {
        private BasicAttackObject Attack;
        private BasicDefenseObject defense;
        private BasicUnit Defender;

        public BasicCombatResolver(BasicAttackObject basicAttackObject, BasicUnit defender)
        {
            Attack = basicAttackObject;
            Defender = defender;
        }

        public int ResolveAttack()
        {
            defense = Defender.DefendAgainstAttack(Attack);

            if (Attack.AttackRoll >= defense.DefenseValue)
            {
                int damage = Attack.Damage - defense.DamageResistance;
                Defender.CurrentHP -= damage;

                return damage;
            }
                
            else
                return 0;
        }
    }
}
