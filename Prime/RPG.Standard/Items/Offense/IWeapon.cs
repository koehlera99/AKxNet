using System;
using RPG.Standard.Combat;
using RPG.Standard.Base;

namespace RPG.Standard.Items.Offense
{
    public interface IWeapon
    {
        WeaponProperty WeaponType { get; set; }
        DamageType DamageType { get; set; }
        WeaponEffects WeaponEffect { get; set; }
        WeaponSlots WeaponSlot { get; set; }
        //Damage WeaponDamage { get; set; }
        Element WeaponElementDamage { get; set; }
        WeaponSlotRestriction WeaponRestriction { get; set; }
        int DamageAmount { get; }

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
