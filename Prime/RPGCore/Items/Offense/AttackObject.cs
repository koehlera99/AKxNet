namespace RPG.Core.Items.Offense
{
    class AttackObject : IAttack
    {
        public AttackObject(AttackType attackType, int attackRoll, int damageRoll)
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
