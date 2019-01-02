using RPG.Standard.Items.Offense;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class MeleeWeaponAttack : WeaponAttack
    {
        public MeleeWeaponAttack(Unit attacker, Unit defender, Weapon weaponUsed) 
            : base(attacker, defender, weaponUsed)
        {
            TotalAttackValue = GetTotalAttackValue();
            DamageAmount = GetDamageAmount();
        }

        public int ReachOfWeapon => WeaponUsed.MaxRange;

        private int MeleeAttackBonus => Attacker.Stats.MeleeAttack.Value;

        private int GetTotalAttackValue()
        {
            int total = 0;

            total += AttackRoll;
            total += WeaponAttackBonus;
            total += WeaponDamageTypeBonus;
            total += MeleeAttackBonus;

            return total;
        }

        private int GetDamageAmount()
        {
            int total = 0;

            total += WeaponUsed.DamageAmount;
            total += TotalAttackValue;
            total *= CritRoll <= Attacker.Stats.CritChance.Value ? Attacker.Stats.CritBonus.Value : 1;

            return total;
        }
    }
}
