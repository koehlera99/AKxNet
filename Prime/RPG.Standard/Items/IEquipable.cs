using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Items
{
    interface IEquipable
    {
        EquipmentSlot Slot { get; }
    }

    public enum EquipmentSlot
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


}
