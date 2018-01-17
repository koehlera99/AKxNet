using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Core.Items
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
}
