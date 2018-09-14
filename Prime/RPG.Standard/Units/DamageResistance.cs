using RPG.Standard.Base;

namespace RPG.Standard.Units
{
    public class DamageResistance
    {
        public string DamageTypeName { get; }
        public WeaponDamageType DamageType { get; }
        public int Value { get; set; }
        public Object Source { get; set; }

        public DamageResistance(string name, int value)
        {
            DamageTypeName = name;
            Value = value;
        }

        public DamageResistance(string name, int value, Object source)
        {
            DamageTypeName = name;
            Value = value;
            Source = source;
        }

        public DamageResistance(WeaponDamageType damageType, int value)
        {
            DamageType = damageType;
            Value = value;
        }

        public DamageResistance(WeaponDamageType damageType, int value, Object source)
        {
            DamageType = damageType;
            Value = value;
            Source = source;
        }
    }
}
