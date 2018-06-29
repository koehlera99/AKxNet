namespace RPG.Standard.Combat
{
    public interface IAttack
    {
        AttackType AttackType { get; }
        int AttackRoll { get; }
        int DamageRoll { get; }
    }

    public enum AttackType
    {
        Melee,
        Ranged,
        Spell
    }
}
