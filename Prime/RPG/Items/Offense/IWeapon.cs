using System;
using RPG.Core.Combat;

namespace RPG.Core.Items.Offense
{
    public interface IWeapon
    {
        WeaponTypes WeaponType { get; set; }
        DamageTypes DamageType { get; set; }
        WeaponEffects WeaponEffect { get; set; }
        WeaponSlots WeaponSlot { get; set; }
        //Damage WeaponDamage { get; set; }
        Element WeaponElementDamage { get; set; }
        WeaponSlotRestriction WeaponRestriction { get; set; }

        IAttack GetAttack();
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

    public enum WeaponSlotRestriction
    {
        None,
        OneHandedOnly,
        TwoHandedOnly,
        OffHandOnly
    }

    //public enum AttackTypes
    //{
    //    None,
    //    Melee,
    //    Ranged,
    //    AOE
    //}
}
