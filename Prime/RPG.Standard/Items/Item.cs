using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG.Core.Effects;
using RPG.Core.Items.Offense;

namespace RPG.Core.Items
{
    public class Item : Object, IItem, IEquipable
    {
        public float Size { get; set; }
        public float Weight { get; set; }

        public short ChanceToFind { get; set; }
        public bool IsEquiped { get; set; }
        public bool IsContainter { get; set; }
        public bool IsTwoHanded { get; set; } = false;

        public int HP { get; set; } = 10;
        public int Energy { get; set; } = 0;

        public IEnumerable<Ability> Abilities { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<IItem> Items { get; set; }

        //public ItemTypes ItemType { get; set; } = ItemTypes.Gear;
        public EquipmentSlot Slot { get; set; } = EquipmentSlot.None;
        public WeaponSlots WeaponLocation { get; set; } = WeaponSlots.PrimaryHand;

        public Item()
        {
            Size = 0;
            Weight = 0;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public Item(int Id, ItemTypes itemType, string itemName, float size, float weight, bool iscontainer, EquipmentSlot equipSlot,
            int hp, int energy, List<Element> elements, List<Property> properties)
        {
            Size = size;
            Weight = weight;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public void UseAbility(int ablitiyId)
        {
            if (Abilities.Count() > 0)
            {
                var abilities =
                    from ability in Abilities
                    where ability.Id == ablitiyId
                    select ability;

                foreach (var a in abilities)
                {
                    a.AbilityFunction.Invoke(new List<AbilityArgs>() { new AbilityArgs(this) });
                }
            }
        }
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
