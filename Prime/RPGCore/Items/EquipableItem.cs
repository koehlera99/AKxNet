using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core.Items
{
    public class EquipableItem : Item
    {
        public MiscSlots EquipmentSlot { get; set; } = MiscSlots.None;

        public EquipableItem()
        {
            //ItemType = ItemTypes.EquipableItem;
        }
    }
}
