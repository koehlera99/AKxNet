using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class BasicCombatResolver
    {
        private BasicAttackObject Attack;
        private BasicDefenseObject Defense;
        private BasicUnit Defender;

        public BasicCombatResolver(BasicAttackObject basicAttackObject)
        {
            Attack = basicAttackObject;
            Defender = basicAttackObject.Defenders.FirstOrDefault();
        }

        public int ResolveAttack()
        {
            Defense = Defender.DefendAgainstAttack(Attack);

            int attackValue = Attack.AttackRoll.FullAttackRoll - Defense.BasicDefenseRoll.FullDefenseRoll;

            if (Attack.AttackRoll.FullAttackRoll >= Defense.BasicDefenseRoll.FullDefenseRoll)
            {
                int damage = Attack.Weapon.DamageAmount - Defense.DamageResistance;
                Defender.CurrentHp -= damage;

                return damage;
            }
            else
            {
                return 0;
            }
        }

        public static int ResolveAttack(BasicAttackObject basicAttackObject)
        {
            var attack = basicAttackObject;
            var defender = basicAttackObject.Defenders.FirstOrDefault();

            var defense = defender.DefendAgainstAttack(attack);

            if (attack.AttackRoll.FullAttackRoll >= defense.BasicDefenseRoll.FullDefenseRoll)
            {
                int damage = attack.Damage - defense.DamageResistance;
                defender.CurrentHp -= damage;

                return damage;
            }

            else
                return 0;
        }
    }
}
