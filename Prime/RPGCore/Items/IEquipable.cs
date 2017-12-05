using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Core.Items
{
    interface IEquipable
    {
        EquipmentSlot Slot { get; }
    }
}
