using RPG.Standard.Base;
using RPG.Standard.Items.Offense;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public abstract class WeaponAttack : Attack
    {
        public WeaponAttack(Unit attacker, Unit defender, Weapon weaponUsed) 
            : base(attacker, defender)
        {
            WeaponUsed = weaponUsed;
        }

        public Weapon WeaponUsed { get; }

        public int WeaponAttackBonus => WeaponUsed.AttackBonus;

        public int WeaponDamageTypeBonus
        {
            get
            {
                switch (WeaponUsed.DamageType)
                {
                    case WeaponDamageType.Piercing:
                        return Attacker.Stats.PiercingWeapons.Value;
                    case WeaponDamageType.Slashing:
                        return Attacker.Stats.SlashingWeapons.Value;
                    case WeaponDamageType.Blunt:
                        return Attacker.Stats.BluntWeapons.Value;
                    default:
                        return 0;
                }
            }
        }


    }
}
