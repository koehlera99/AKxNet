using System;
using RPG.Core.Combat;
using RPG.Core.Units;

namespace RPG.Core.Items.Offense
{
    //interface IWeapon
    //{
    //    string WeaponName { get; set; }

    //    WeaponTypes WeaponType { get; set; }
    //    DamageTypes DamageType { get; set; }
    //    WeaponEffects WeaponEffect { get; set; }
    //    WeaponSlots WeaponSlot { get; set; }
    //    Damage WeaponDamage { get; set; }
    //    Element WeaponElementDamage { get; set; }
    //    WeaponSlotRestriction WeaponRestriction { get; set; }
    //}

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

        public int MinDamage { get; set; } = 1;
        public int MaxDamage { get; set; } = 10;

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

        public int DamageAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DamageType IDamage.DamageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

    public enum WeaponEffects
    {
        None,
        Bleed,  // Slashing
        Stun,   // Blunt
        Sunder, // Any
        Trip,   // Reach
        Disarm  // Any
    }


    public enum WeaponTypes
    {
        None,
        Throwing,       //Light weapons: Daggers, Javalins
        Martial,        //Medium One-Handed weapons
        TwoHanded,      //Medium Two-Handed EquipedWeapons
        LightRanged,    //One-Handed Ranged EquipedWeapons
        HeavyRanged     //Two-Handed Ranged EquipedWeapons
    }

    [Flags]
    public enum DamageTypes
    {
        None = 0,
        Piercing = 1,  // Penetration
        Slashing = 2,  // Bleed (Physical DOT)
        Blunt = 4,     // Stun

        Fire = 8,
        Electric = 16,
        Bio = 32,
        Force = 64,
        Radiant = 128,
        Shadow = 256,
        Ice = 512
    }

    [Flags]
    public enum WeaponSlots
    {
        None = 0,
        PrimaryHand = 1,
        OffHand = 2
    }



    //public enum AttackTypes
    //{
    //    None,
    //    Melee,
    //    Ranged,
    //    AOE
    //}



    public enum WeaponSlotRestriction
    {
        None,
        OneHandedOnly,
        TwoHandedOnly,
        OffHandOnly
    }
}
