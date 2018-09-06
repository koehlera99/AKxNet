using System;

namespace RPG.Standard.Items
{
    [Flags]
    public enum WeaponSlots
    {
        None = 0,
        PrimaryHand = 1,
        OffHand = 2
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

    [Flags]
    public enum ArtifactSlots
    {
        None = 0,
        Attack = 1,
        Defense = 2,
        Support = 4,
        Effect = 8
    }
}