namespace RPG.Standard.Combat
{
    public interface IDamage
    {
        int DamageAmount { get; set; }
        PrimaryDamageType DamageType { get; set; }

        IDamage GetDamage();
    }

    public enum PrimaryDamageType
    {
        Physical,
        Arcane,
        Nature,
        Holy
    }
}
