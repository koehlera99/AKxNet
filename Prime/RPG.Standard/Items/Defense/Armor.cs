using RPG.Standard.Base;
using RPG.Standard.Stats;

namespace RPG.Standard.Items.Defense
{
    public class Armor : Item
    {
        private int _armorClass;
        private int _resistBlunt = 0;
        private int _resistPiercing = 0;
        private int _resistSlashing = 0;

        public ArmorTypeFlag ArmorTypes { get; set; }
        public HardnessScale ArmorHardness { get; set; }
        public ArmorSlots ArmorSlot { get; set; }

        public int DefenseBonus { get; set; }
        public float MaxDexReduction { get; set; }

        public int ArmorClass => _armorClass + ArmorSizeRating + ArmorHardnessValue;
        public int ArmorSizeRating => (int)ArmorSize;
        public int ArmorHardnessValue => (int)ArmorHardness;

        public Armor()
        {
            Name = "EquipedArmor";
            Energy = 1;
        }

        public Armor(int id, int defenseBonus, HardnessScale armorHardness, ArmorTypeFlag armorType, int armorClass)
        {
            Id = id;
            Name = "EquipedArmor";
            DefenseBonus = defenseBonus;
            ArmorHardness = armorHardness;
            ArmorTypes = armorType;
            _armorClass = armorClass;

            Energy = 1;
        }

        public int ResistBlunt
        {
            get
            {
                if (ArmorTypes == ArmorTypeFlag.Scale || ArmorTypes == ArmorTypeFlag.Plate)
                    return _resistBlunt * ArmorHardnessValue;
                else
                    return _resistBlunt;
            }
        }

        public int ResistPiercing
        {
            get
            {
                if (ArmorTypes == ArmorTypeFlag.Chain || ArmorTypes == ArmorTypeFlag.Plate)
                    return _resistPiercing * ArmorHardnessValue;
                else
                    return _resistPiercing;
            }
        }

        public int ResistSlashing
        {
            get
            {
                if (ArmorTypes == ArmorTypeFlag.Ring || ArmorTypes == ArmorTypeFlag.Plate)
                    return _resistSlashing * ArmorHardnessValue;
                else
                    return _resistSlashing;
            }
        }

        public int GetResistAmount(WeaponDamageType type)
        {
            if ((ResistDamageType & type) != 0)
                return ArmorHardnessValue * 5;
            else
                return 0;
        }

        public ArmorSize ArmorSize
        {
            get
            {
                switch (ArmorTypes)
                {
                    case ArmorTypeFlag.Cloth:
                        return ArmorSize.Light;
                    case ArmorTypeFlag.Leather:
                        return ArmorSize.Light;
                    case ArmorTypeFlag.Chain:
                        return ArmorSize.Medium;
                    case ArmorTypeFlag.Scale:
                        return ArmorSize.Medium;
                    case ArmorTypeFlag.Ring:
                        return ArmorSize.Medium;
                    case ArmorTypeFlag.Plate:
                        return ArmorSize.Heavy;
                    default:
                        return ArmorSize.Light;
                }
            }
        }

        public WeaponDamageType ResistDamageType
        {
            get
            {
                switch (this.ArmorTypes)
                {
                    case ArmorTypeFlag.Cloth:
                        return WeaponDamageType.None;
                    case ArmorTypeFlag.Leather:
                        return WeaponDamageType.None;
                    case ArmorTypeFlag.Chain:
                        return WeaponDamageType.Piercing;
                    case ArmorTypeFlag.Scale:
                        return WeaponDamageType.Blunt;
                    case ArmorTypeFlag.Ring:
                        return WeaponDamageType.Slashing;
                    case ArmorTypeFlag.Plate:
                        return WeaponDamageType.Piercing | WeaponDamageType.Slashing | WeaponDamageType.Blunt;
                    default:
                        return WeaponDamageType.None;
                }
            }
        }
    }
}
