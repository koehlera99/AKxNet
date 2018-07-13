using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Combat;
using RPG.Standard.Tools;
using RPG.Standard.Items.Offense;

namespace RPG.Standard.Units
{
    class BasicUnit
    {
        public int BasicAttackValue { get; set; }
        public int BasicDefenseValue { get; set; }

        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }

        //public int AttackRoll => Roll.D100() + BasicAttackValue;

        public AttackRoll UnitAttackRoll => new AttackRoll(BasicAttackValue);

        public int PerformAttack(IWeapon weapon, BasicUnit defender)
        {
            var defenders = new List<BasicUnit>() {defender};
            var attack = new BasicAttackObject(UnitAttackRoll, weapon, this, defenders);
            //var combatResolver = new BasicCombatResolver(attack);

            return BasicCombatResolver.ResolveAttack(attack);
            //return combatResolver.ResolveAttack();
        }

        public BasicDefenseObject DefendAgainstAttack(BasicAttackObject attack)
        {
            return new BasicDefenseObject(BasicDefenseValue);
        }
    }
}
