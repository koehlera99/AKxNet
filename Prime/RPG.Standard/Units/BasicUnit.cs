using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Combat;
using RPG.Standard.Items.Offense;
using RPG.Standard.Tools;

namespace RPG.Standard.Units
{
    public class BasicUnit : Object
    {
        public int BasicAttackValue { get; set; }
        public int BasicDefenseValue { get; set; }

        public int DamageResistanceTest => 0;

        public int MaxHp { get; set; }
        public int MaxPower { get; set; }
        public int MaxMagic { get; set; }
        public int MaxEnergy { get; set; }

        public int CurrentHp { get; set; }
        public int CurrentPower { get; set; }
        public int CurrentMagic { get; set; }
        public int CurrentEnergy { get; set; }

        public BasicUnit() { }

        public BasicUnit(int maxHp, int maxPower, int maxMagic, int maxEnergy)
        {
            MaxHp = maxHp;
            MaxPower = maxPower;
            MaxMagic = maxMagic;
            MaxEnergy = maxEnergy;

            //Testing only
            CurrentHp = (int)(MaxHp * 0.9);
            CurrentPower = (int)(MaxPower * 0.7);
            CurrentMagic = (int)(MaxMagic * 0.53);
            CurrentEnergy = (int)(MaxEnergy * 0.25);
        }

        public int? PerformAttack(BasicUnit defender, IWeapon weapon)
        {
            var defenders = new List<BasicUnit>() { defender };
            var attackRoll = new AttackRoll(this);

            var attack = new BasicAttackObject(attackRoll, weapon, this, defenders);
            var combatResolver = new BasicCombatResolver(attack);

            return combatResolver.ResolveAttack();
        }

        public BasicDefenseObject DefendAgainstAttack(BasicAttackObject attack)
        {
            return new BasicDefenseObject(this);
        }
    }
}
