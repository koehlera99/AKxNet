using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.RPG.Effects;

namespace TCS.RPG.Items
{
    public class Item : RPGObject //: IEquatable<Item>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Size { get; set; } = 0.1f;
        public float Weight { get; set; }

        public short ChanceToFind { get; set; }
        public bool IsEquiped { get; set; }
        public bool IsContainter { get; set; }
        public bool IsTwoHanded { get; set; } = false;

        public int HP { get; set; } = 10;
        public int Energy { get; set; } = 0;

        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Material> Materials { get; set; } = new List<Material>();
        public List<Property> Properties { get; set; } = new List<Property>();

        public List<Item> ItemsContained { get; set; }

        //public ItemTypes ItemType { get; set; } = ItemTypes.Gear;
        public EquipmentSlots EquipLocation { get; set; } = EquipmentSlots.None;
        public WeaponSlots WeaponLocation { get; set; } = WeaponSlots.PrimaryHand;

        public Item() : base(RPGObjectType.Item)
        {
            Size = 0;
            Weight = 0;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public Item(int itemID, ItemTypes itemType, string itemName, float size, float weight, bool iscontainer, EquipmentSlots equipSlot,
            int hp, int energy, List<Element> elements, List<Property> properties) : base(RPGObjectType.Item)
        {
            Size = size;
            Weight = weight;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public void UseAbility(int ablitiyID)
        {
            if (Abilities.Count > 0)
            {
                var abilities =
                    from ability in Abilities
                    where ability.ID == ablitiyID
                    select ability;

                foreach (var a in abilities)
                {
                    a.AbilityFunction.Invoke(new List<AbilityArgs>() { new AbilityArgs(this) });
                }
            }
        }
    }

    public enum ItemTypes
    {
        Gear,
        Weapon,
        Armor,
        Clothing,
        Ammunition,
        Artifact,
        EquipableItem
    }



    [Flags]
    public enum MiscSlots
    {
        None = 0,
        LeftRing = 1,
        RightRing = 2,
        Neckless = 4,
        Cloak = 8,
        Eyes = 16,
        IonStone = 32
    }





    ////TODO: Remove ??
    //enum EquipableItems
    //{
    //    None,
    //    Clothes,
    //    Weapon,
    //    OneHandedWeapon,
    //    TwoHandedWeapon,
    //    Shield,
    //    Armor,
    //    Helmet,
    //    Boots,
    //    Necklace,
    //    Ring,
    //    Bracelet,
    //    Glasses,
    //    Gloves,
    //    Misc
    //}

    //TODO: Remove ??
    public enum EquipmentSlots
    {
        None,
        PrimaryHand,
        OffHand,
        BothHands,
        Head,
        Body,
        Arms,
        Feet,
        Wrists,
        Hands,
        Neck,
        LeftFinger,
        RightFinger,
        Cloak,
        Eyes,
        Misc
    }

    ////TODO: Remove ??
    //enum RingSlots
    //{
    //    LeftPointer,
    //    LeftMiddle,
    //    LeftRing,
    //    RightPointer,
    //    RightMiddle,
    //    RightRing,
    //}

    //class Modify
    //{
    //    public int ModifyID { get; set; }
    //    public string ModifyName { get; set; }
    //    public string ModifyType { get; set; }
    //    public int ModifyValue { get; set; }
    //    public string ModifyDescription { get; set; }

    //    public Modify() { }
    //    public Modify(int id, string name, string type, int value, string desc)
    //    {
    //        ModifyID = id;
    //        ModifyName = name;
    //        ModifyType = type;
    //        ModifyValue = value;
    //        ModifyDescription = desc;
    //    }
    //}



}
