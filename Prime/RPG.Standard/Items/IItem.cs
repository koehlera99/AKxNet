using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Items
{
    public interface IItem
    {
        float Size { get; set; }
        float Weight { get; set; }
        IEnumerable<Material> Materials { get; set; }
        IEnumerable<IItem> Items { get; set; }
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

    enum ItemQuality
    {
        Horrible,
        Poor,
        Average,
        Good,
        High,
        Masterwork,
        Legendary,
        Epic
    }
}
