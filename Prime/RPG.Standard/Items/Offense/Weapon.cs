using System;
using RPG.Standard.Combat;
using RPG.Standard.Units;
using RPG.Standard.Tools;

namespace RPG.Standard.Items.Offense
{
    public class Weapon : Item, IWeapon, IDamage
    {
        public WeaponTypes WeaponType { get; set; }
        public DamageTypes DamageType { get; set; }
        public WeaponEffects WeaponEffect { get; set; }
        public WeaponSlots WeaponSlot { get; set; } = WeaponSlots.None;
        public Damage WeaponDamage { get; set; }
        public Element WeaponElementDamage { get; set; }
        public WeaponSlotRestriction WeaponRestriction { get; set; }

        public int DefenseBonus { get; set; } = 0;
        public int AttackBonus { get; set; } = 0;

        public int ParryChance { get; set; } = 0;
        public int BlockChance { get; set; } = 0;

        public int CritChanceBonus { get; set; } = 0;
        public int CritDamageBonus { get; set; } = 0;

        

        public int MinRange { get; set; } = 0; //Self
        public int MaxRange { get; set; } = 1; //Melee

        //BaseStats that are used when using this weapon (Strength: Melee, Dexterity: Ranged, Finesse)
        public BaseStat PrimaryWeaponStat { get; set; } = BaseStat.Strength;
        public SecondaryStat SecondaryWeaponsStat { get; set; } = SecondaryStat.None;

        public WeaponEffects WeaponEffectList
        {
            get
            {
                WeaponEffects effects = WeaponEffects.None;

                if (DamageType == DamageTypes.Blunt)
                    effects = effects | WeaponEffects.Stun;
                if (DamageType == DamageTypes.Piercing)
                    effects = effects | WeaponEffects.Sunder;
                if (DamageType == DamageTypes.Slashing)
                    effects = effects | WeaponEffects.Bleed;

                //Clean up
                if (effects != WeaponEffects.None)
                    effects = effects ^ WeaponEffects.None;

                return effects;
            }
        }

        public int DamageAmount => Roll.Dice(DamageDie);

        public int MinDamage { get; } = 1;
        public int MaxDamage { get; set; } = 10;

        public Die DamageDie { get; set; } = Die.D6;
        PrimaryDamageType IDamage.DamageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Weapon()
        {
            Name = "Basic Weapon";
            //ItemType = ItemTypes.Weapon;
            Size = 1;
            Weight = 1;
        }

        public Weapon(float size, float weight, string name) //: base(size, weight, false)
        {
            Name = name;
            //ItemType = ItemTypes.Weapon;
            Size = size;
            Weight = weight;
        }

        public int DealDamageValue()
        {
            Random r = new Random();
            return r.Next(MinDamage, MaxDamage + 1);
        }

        public Damage DealDamage()
        {
            return new Damage(DealDamageValue(), DamageType);
        }

        public Damage DealDamage(int damageModifier)
        {
            return new Damage(DealDamageValue() + damageModifier, DamageType);
        }

        public IAttack GetAttack()
        {
            throw new NotImplementedException();
        }

        public IDamage GetDamage()
        {
            throw new NotImplementedException();
        }
    }
}
