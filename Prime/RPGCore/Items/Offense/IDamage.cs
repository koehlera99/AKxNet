namespace RPG.Core.Items.Offense
{
    public interface IDamage
    {
        int DamageAmount { get; set; }
        DamageType DamageType { get; set; }

        IDamage GetDamage();
    }

    public enum DamageType
    {
        Weapon,
        Magic
    }
}
