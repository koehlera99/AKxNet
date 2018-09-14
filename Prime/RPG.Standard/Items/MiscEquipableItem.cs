using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Items
{
    public class MiscEquipableItem : Item
    {
        public MiscSlots EquipmentSlot { get; set; } = MiscSlots.None;

        public MiscEquipableItem()
        {

        }
    }
}
