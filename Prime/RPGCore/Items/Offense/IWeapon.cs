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
}
