using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public abstract class Attack
    {
        public Attack(Unit attacker, Unit defender)
        {
            Attacker = attacker;
            Defender = defender;

            AttackRoll = Tools.Roll.D100;
            CritRoll = Tools.Roll.D100;
        }

        public Unit Attacker { get; }
        public Unit Defender { get; }
        
        public int AttackRoll { get; }
        public int CritRoll { get; }

        public int TotalAttackValue { get; protected set; }
        public int DamageAmount { get; protected set; }
    }
}
