using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class Defense
    {
        public Defense(Attack attack)
        {
            Attack = attack;

            DefenseRoll = 0; // Tools.Roll.D100;
        }

        public Attack Attack { get; }

        public int DefenseRoll { get; }
        public int TotalDefenseValue { get; protected set; }

        public void DefendAgainstAttack()
        {
            int damage;

            if (Attack.TotalAttackValue > TotalDefenseValue)
                damage = (Attack.TotalAttackValue - TotalDefenseValue) * Attack.Attacker.Stats.UnitLevel.Bonus;
            else
                damage = 1 * Attack.Attacker.Stats.UnitLevel.Bonus;

            Attack.Defender.ApplyWeaponDamage(damage);
        }
    }
}
