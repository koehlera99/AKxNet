using System;

namespace RPG.Standard.Base
{
    [Flags]
    public enum Condition
    {
        None = 0,
        Sleep = 1,
        Poisoned = 2,
        Confused = 4,
        Petrified = 8,
        Restrained = 16,
        Paralyzed = 32,
        Fear = 64,
        Dazed = 128,
        Stun = 256,
        Dominated = 512,
        Exhausted = 1024,
        Diseased = 2048,
        Berserk = 4096,
        Silence = 8192
    }

    public enum DamageType
    {
        None,
        Blunt,
        Slashing,
        Piercing
    }

    [Flags]
    public enum WeaponProperty
    {
        Throwing = 1,
        Light = 2,
        Heavy = 4,
        Finese = 8,
        Versatile = 16,
        TwoHanded = 32,
        Loading = 64,
        Ranged = 128,
        Reach = 256,
        Ammunition = 512
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Chain,
        Ring,
        Scale,
        Plate,
        Shield
    }

    [Flags]
    public enum Element
    {
        None = 0,
        Air = 1,
        Ice = 2,
        Water = 4,
        Poison = 8,
        Earth = 16,
        Acid = 32,
        Fire = 64,
        Thunder = 128,
        Electric = 256,
        Radiant = 512,
        Psionic = 1024,
        Shadow = 2048,
        Force = 4096
    }

    public enum CreatureType
    {
        Humanoid,
        Fey,
        Dragon,
        Giant,
        Undead,
        Aberration,
        Monstrosity,
        Beast,
        Fiend,
        Elemental,
        Construct,
        Celestial,
        Plant
    }
}
