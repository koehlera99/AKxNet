namespace RPG.Standard.Combat
{
    class Attack : IAttack
    {
        public Attack(AttackType attackType, int attackRoll, int damageRoll)
        {
            AttackType = attackType;
            AttackRoll = attackRoll;
            DamageRoll = damageRoll;

        }

        public AttackType AttackType { get; }
        public int AttackRoll { get; }
        public int DamageRoll { get; }
    }
}
