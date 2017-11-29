using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Items
{
    public class Armor : Item
    {
        //new
        public int Hardness { get; set; } // 1 - 10?


        //old
        public ArmorTypes ArmorType { get; set; }
        public HardnessScale ArmorHardness { get; set; }
        public ArmorSlots ArmorSlot { get; set; }

        public int DefenseBonus { get; set; }
        public float MaxDexReduction { get; set; }
        public string ArmorName { get; set; }

        //new
        private int _ac;

        private int _resistBlunt;
        private int _resistPiercing;
        private int _resistSlashing;

        // Uses weighted AC based on Armor Slot
        public int AC
        {
            get { return (int)((_ac + Hardness) * WeightedAC[ArmorSlot]); }
        }

        public int ResistBlunt
        {
            get
            {
                if (this.ArmorType == ArmorTypes.Scale || this.ArmorType == ArmorTypes.Plate)
                    return _resistBlunt * Hardness;
                else
                    return _resistBlunt;
            }
        }

        public int ResistPiercing
        {
            get
            {
                if (this.ArmorType == ArmorTypes.Chain || this.ArmorType == ArmorTypes.Plate)
                    return _resistBlunt * Hardness;
                else
                    return _resistBlunt;
            }
        }

        public int ResistSlashing
        {
            get
            {
                if (this.ArmorType == ArmorTypes.Ring || this.ArmorType == ArmorTypes.Plate)
                    return _resistBlunt * Hardness;
                else
                    return _resistBlunt;
            }
        }

        public int ArmorSizeRating
        {
            get { return (int)ArmorSize; }
        }

        public ArmorSize ArmorSize
        {
            get
            {
                switch (this.ArmorType)
                {
                    case ArmorTypes.Cloth:
                        return ArmorSize.Light;
                    case ArmorTypes.Leather:
                        return ArmorSize.Light;
                    case ArmorTypes.Banded:
                        return ArmorSize.Medium;
                    case ArmorTypes.Chain:
                        return ArmorSize.Medium;
                    case ArmorTypes.Scale:
                        return ArmorSize.Medium;
                    case ArmorTypes.Ring:
                        return ArmorSize.Medium;
                    case ArmorTypes.Plate:
                        return ArmorSize.Heavy;
                    default:
                        return ArmorSize.Light;
                }
            }
        }

        readonly Dictionary<ArmorSlots, double> WeightedAC = new Dictionary<ArmorSlots, double>()
        {
            { ArmorSlots.Body, 0.45 },
            { ArmorSlots.Head, 0.10 },
            { ArmorSlots.Legs, 0.15 },
            { ArmorSlots.Feet, 0.10 },
            { ArmorSlots.Arms, 0.15 },
            { ArmorSlots.Hands, 0.05 }

        };

        public Armor()
        {
            //ItemType = ItemTypes.Armor;
            Name = "EquipedArmor";
            ArmorName = "Basic EquipedArmor";
        }

        public Armor(int id, string name, int defenseBonus, HardnessScale armorHardness, ArmorTypes armorType)
        {
            //base();
            ID = id;
            Name = "EquipedArmor";
            //ItemType = ItemTypes.Armor;
            ArmorName = Name;
            DefenseBonus = defenseBonus;
            ArmorHardness = armorHardness;
            ArmorType = armorType;
        }

        public DamageTypes ResistDamageType
        {
            get
            {
                switch (this.ArmorType)
                {
                    case ArmorTypes.Cloth:
                        return DamageTypes.None;
                    case ArmorTypes.Leather:
                        return DamageTypes.None;
                    case ArmorTypes.Banded:
                        return DamageTypes.None;
                    case ArmorTypes.Chain:
                        return DamageTypes.Piercing;
                    case ArmorTypes.Scale:
                        return DamageTypes.Blunt;
                    case ArmorTypes.Ring:
                        return DamageTypes.Slashing;
                    case ArmorTypes.Plate:
                        return DamageTypes.Piercing | DamageTypes.Slashing | DamageTypes.Blunt;
                    default:
                        return DamageTypes.None;
                }
            }
        }


        //EquipedArmor Rating
        public int ArmorClass
        {
            get { return AC; }
            //get { return ArmorSizeRating + ArmorHardnessValue + DefenseBonus ; }
        }

        //Hardnes integer value
        public int ArmorHardnessValue
        {
            get { return (int)ArmorHardness; }
        }

        ////new
        //public int AC
        //{
        //    get { return BaseAC + Hardness + DefenseBonus; }
        //}

        //new
        //public int BaseAC
        //{
        //    get
        //    {
        //        switch (this.ArmorType)
        //        {
        //            case ArmorTypes.Cloth:
        //                return 40;
        //            case ArmorTypes.Leather:
        //                return 50;
        //            case ArmorTypes.Banded:
        //                return 60;
        //            case ArmorTypes.Chain:
        //                return 60;
        //            case ArmorTypes.Scale:
        //                return 60;
        //            case ArmorTypes.Ring:
        //                return 60;
        //            case ArmorTypes.Plate:
        //                return 80;
        //            default:
        //                return 40;
        //        }
        //    }
        //}

        public int GetResistAmount(DamageTypes type)
        {
            if ((ResistDamageType & type) != 0) //|| ArmorType == ArmorTypes.Plate)
                return Hardness * 5;
            else
                return 0;


        }
    }

    //new
    public enum ArmorTypes
    {
        Cloth, 
        Leather, 
        Banded, 
        Chain,  // P
        Ring,   // S
        Scale,  // B
        Plate   // P,S,B
    }

    //Splint Mail, Banded Mail, Spiked EquipedArmor

    public enum ArmorSize
    {
        Light = 1,
        Medium = 2,
        Heavy = 3
    }

    [Flags]
    public enum ArmorSlots
    {
        Head = 1,
        Body = 2,
        Feet = 4,
        Hands = 8,
        Arms = 16,
        Legs = 32
    }
}
