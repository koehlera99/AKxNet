using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Combat;
using RPG.Standard.Tools;

namespace RPG.Standard.Units
{
    class BasicUnit
    {
        public int BasicAttackValue { get; set; }
        public int BasicDefenseValue { get; set; }

        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }

        public int PerformAttack(BasicUnit defender)
        {
            //TODO: Replace with weapon damage
            int damage = 5;

            int attackRoll = Roll.D100() + BasicAttackValue;

            var attack = new BasicAttackObject(attackRoll, damage);
            var combatResolver = new BasicCombatResolver(attack, defender);

            return combatResolver.ResolveAttack();
        }

        public BasicDefenseObject DefendAgainstAttack(BasicAttackObject attack)
        {
            return new BasicDefenseObject(BasicDefenseValue);
        }
    }
}
