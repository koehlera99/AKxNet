using RPG.Standard.Items.Offense;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    class RangedWeaponAttack : WeaponAttack 
    {
        public RangedWeaponAttack(Unit attacker, Unit defender, Weapon weaponUsed) 
            : base(attacker, defender, weaponUsed)
        {

        }

        public int RangeOfWeapon { get; set; }
    }
}
