using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Combat
{
    public class MeleeWeaponDefense : WeaponDefense
    {
        public MeleeWeaponDefense(MeleeWeaponAttack attack)
            : base(attack)
        {
            ParryRoll = Tools.Roll.D100;

            TotalDefenseValue = GetTotalDefenseValue();
        }

        public int ParryRoll { get; }
        public int ParryDefenseValue => ParryRoll <= Attack.Defender.Stats.ParryChance.Value ? Attack.Defender.Stats.ParryBonus.Value : 0;

        public int GetTotalDefenseValue()
        {
            int total = DefenseRoll + BlockDefenseValue + DodgeDefenseValue + ParryDefenseValue;

            total += Attack.Defender.Stats.ArmorClass.Value;
            total += WeaponDamageTypeResistance;

            return total;
        }
    }
}
