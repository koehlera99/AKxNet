using RPG.Standard.Base;
using RPG.Standard.Combat;
using RPG.Standard.Stats;
using RPG.Standard.Tools;
using System;

namespace RPG.Standard.Items.Offense
{
    public class Weapon : Item
    {
        public WeaponProperty WeaponType { get; set; }
        public WeaponDamageType DamageType { get; set; }
        public WeaponEffects WeaponEffect { get; set; }
        public WeaponSlots WeaponSlot { get; set; } = WeaponSlots.None;
        //public Damage WeaponDamage { get; set; }
        public PhysicalElement WeaponElementDamage { get; set; }
        public WeaponSlotRestriction WeaponRestriction { get; set; }

        public int DefenseBonus { get; set; } = 0;
        public int AttackBonus { get; set; } = 0;

        public int ParryChance { get; set; } = 0;
        public int BlockChance { get; set; } = 0;

        public int CritChanceBonus { get; set; } = 0;
        public int CritDamageBonus { get; set; } = 0;

        public int MinRange { get; set; } = 0; //Self
        public int MaxRange { get; set; } = 1; //Melee

        public PrimaryFlag PrimaryWeaponStat { get; set; } = PrimaryFlag.Str;
        public int DamageAmount => Roll.Dice(DamageDie);
        public int MinDamage { get; } = 1;
        public int MaxDamage { get; set; } = 10;
        public Die DamageDie { get; set; } = Die.D6;

        public WeaponEffects WeaponEffectList
        {
            get
            {
                WeaponEffects effects = WeaponEffects.None;

                if (DamageType == WeaponDamageType.Blunt)
                    effects = effects | WeaponEffects.Stun;
                if (DamageType == WeaponDamageType.Piercing)
                    effects = effects | WeaponEffects.Sunder;
                if (DamageType == WeaponDamageType.Slashing)
                    effects = effects | WeaponEffects.Bleed;

                //Clean up
                if (effects != WeaponEffects.None)
                    effects = effects ^ WeaponEffects.None;

                return effects;
            }
        }

        public Weapon()
        {
            Name = "Basic Weapon";
            Size = 1;
            Weight = 1;
        }

        public Weapon(float size, float weight, string name) //: base(size, weight, false)
        {
            Name = name;
            Size = size;
            Weight = weight;
        }

        public int DealDamageValue()
        {
            Random r = new Random();
            return r.Next(MinDamage, MaxDamage + 1);
        }

        //public Damage DealDamage()
        //{
        //    return new Damage(DealDamageValue(), DamageType);
        //}

        //public Damage DealDamage(int damageModifier)
        //{
        //    return new Damage(DealDamageValue() + damageModifier, DamageType);
        //}
    }
}
