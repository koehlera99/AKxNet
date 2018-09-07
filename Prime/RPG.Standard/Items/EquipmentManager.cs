using RPG.Standard.Base;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Standard.Items
{
    public class EquipmentManager
    {
        protected Dictionary<WeaponSlots, Weapon> EquipedWeapons { get; set; } = new Dictionary<WeaponSlots, Weapon>();
        protected Dictionary<ArmorSlots, Armor> EquipedArmor { get; set; } = new Dictionary<ArmorSlots, Armor>();
        protected Dictionary<MiscSlots, EquipableItem> MiscEquipment { get; set; } = new Dictionary<MiscSlots, EquipableItem>();
        protected Dictionary<ArtifactSlots, Artifact> EquipedArtifacts { get; set; } = new Dictionary<ArtifactSlots, Artifact>();
        protected List<Item> Items { get; set; } = new List<Item>();

        public Weapon EquipedWeapon => EquipedWeapons[WeaponSlots.PrimaryHand];

        public int EquipedArmorClass => EquipedWeapons.Sum(x => x.Value.DefenseBonus) + EquipedArmor.Sum(x => x.Value.ArmorClass);
        public int ArmorDexReduction => (int)EquipedArmor.Sum(x => x.Value.MaxDexReduction);

        public Stat BluntResist { get; }
        public Stat PierceResist { get; private set; }
        public Stat SlashResist { get; private set; }

        public EquipmentManager()
        {
            EquipedWeapons = new Dictionary<WeaponSlots, Weapon>();
            EquipedArmor = new Dictionary<ArmorSlots, Armor>();
            MiscEquipment = new Dictionary<MiscSlots, EquipableItem>();
            EquipedArtifacts = new Dictionary<ArtifactSlots, Artifact>();
            Items = new List<Item>();

            BluntResist = new Stat();
            PierceResist = new Stat();
            SlashResist = new Stat();

            RefreshEquipmentStats();
        }

        private int GetBluntResist()
        {
            return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Scale || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);
        }

        private int GetPierceResist()
        {
            return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Chain || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);
        }

        private int GetSlashResist()
        {
            return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Ring || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);
        }

        private void RefreshEquipmentStats()
        {
            BluntResist.Set(GetBluntResist());
            PierceResist.Set(GetPierceResist());
            SlashResist.Set(GetSlashResist());
        }

        public void EquipArmor(Armor armor)
        {
            UnEquipArmor(armor.ArmorSlot);
            armor.IsEquiped = true;
            EquipedArmor.Add(armor.ArmorSlot, armor);

            RefreshEquipmentStats();
        }

        public void UnEquipArmor(ArmorSlots slot)
        {
            if (EquipedArmor.ContainsKey(slot))
            {
                EquipedArmor[slot].IsEquiped = false;
                Items.Add(EquipedArmor[slot]);
                EquipedArmor.Remove(slot);

                RefreshEquipmentStats();
            }
        }

        public void EquipMiscItem(EquipableItem item)
        {
            UnEquipMiscItem(item.EquipmentSlot);
            item.IsEquiped = true;
            MiscEquipment.Add(item.EquipmentSlot, item);
        }

        public void UnEquipMiscItem(MiscSlots slot)
        {
            if (MiscEquipment.ContainsKey(slot))
            {
                MiscEquipment[slot].IsEquiped = false;
                Items.Add(MiscEquipment[slot]);
                MiscEquipment.Remove(slot);
            }
        }

        public void EquipArtifact(Artifact artifact)
        {
            UnEquipArtifact(artifact.ArtifactSlot);
            artifact.IsEquiped = true;
            EquipedArtifacts.Add(artifact.ArtifactSlot, artifact);
        }

        public void UnEquipArtifact(ArtifactSlots slot)
        {
            if (EquipedArtifacts.ContainsKey(slot))
            {
                EquipedArtifacts[slot].IsEquiped = false;
                Items.Add(EquipedArtifacts[slot]);
                EquipedArtifacts.Remove(slot);
            }
        }

        public bool EquipWeapon(Weapon weapon, WeaponSlots slot = WeaponSlots.None)
        {
            weapon.IsEquiped = false;
            weapon.WeaponSlot = WeaponSlots.None;

            if (slot == WeaponSlots.None)
            {
                slot = weapon.WeaponSlot;
            }

            switch (weapon.WeaponRestriction)
            {
                case WeaponSlotRestriction.None:
                    break;
                case WeaponSlotRestriction.OffHandOnly:
                    if (slot != WeaponSlots.OffHand)
                        return false;
                    break;
                case WeaponSlotRestriction.OneHandedOnly:
                    if (slot.HasFlag(WeaponSlots.PrimaryHand) && slot.HasFlag(WeaponSlots.OffHand))
                        return false;
                    break;
                case WeaponSlotRestriction.TwoHandedOnly:
                    if (!(slot.HasFlag(WeaponSlots.PrimaryHand) && slot.HasFlag(WeaponSlots.PrimaryHand)))
                        return false;
                    break;
                default:
                    break;
            }

            if (slot.HasFlag(WeaponSlots.PrimaryHand))
                UnEquipWeapon(WeaponSlots.PrimaryHand);

            if (slot.HasFlag(WeaponSlots.OffHand))
                UnEquipWeapon(WeaponSlots.OffHand);

            if (EquipedWeapons.ContainsKey(WeaponSlots.PrimaryHand | WeaponSlots.OffHand))
                UnEquipWeapon(WeaponSlots.PrimaryHand | WeaponSlots.OffHand);

            EquipedWeapons.Add(slot, weapon);
            weapon.IsEquiped = true;
            weapon.WeaponSlot = slot;

            return true;
        }

        public void UnEquipWeapon(Weapon weapon)
        {
            weapon.IsEquiped = false;

            if (EquipedWeapons.ContainsKey(weapon.WeaponSlot))
            {
                Items.Add(weapon);
                EquipedWeapons.Remove(weapon.WeaponSlot);
                weapon.WeaponSlot = WeaponSlots.None;
            }
        }

        public void UnEquipWeapon(WeaponSlots weaponSlot)
        {
            if (EquipedWeapons.ContainsKey(weaponSlot))
            {
                EquipedWeapons[weaponSlot].IsEquiped = false;
                Items.Add(EquipedWeapons[weaponSlot]);
                EquipedWeapons.Remove(weaponSlot);
            }
        }

        public bool EquipItem(Item item)
        {
            if (item is Weapon)
                EquipWeapon((Weapon)item);
            else if (item is Armor)
                EquipArmor((Armor)item);
            else if (item is EquipableItem)
                EquipMiscItem((EquipableItem)item);
            else if (item is Artifact)
                EquipArtifact((Artifact)item);
            else
                return false;

            return true;
        }

        public float PickUpItem(Item item)
        {
            Items.Add(item);

            return GetWeightCarried();
        }

        public float DropItem(string name, int quantity = 1)
        {
            foreach (Item i in Items)
            {
                if (i.Name == name)
                {
                    Items.Remove(i);
                    quantity--;

                    if (quantity < 1)
                        break;
                }
            }

            return GetWeightCarried();
        }

        public float DropItem(int itemID, int quantity = 1)
        {
            foreach (Item i in Items)
            {
                if (i.Id == itemID)
                {
                    Items.Remove(i);
                    quantity--;

                    if (quantity < 1)
                        break;
                }
            }

            return GetWeightCarried();
        }

        public float DropItem(Item item, int quantity = 1)
        {
            for (int i = quantity; i > 0; i--)
                Items.Remove(item);

            return GetWeightCarried();
        }

        public float GetWeightCarried()
        {
            float wt =
                Items.Sum(x => x.Weight) +
                EquipedWeapons.Sum(x => x.Value.Weight) +
                EquipedArmor.Sum(x => x.Value.Weight) +
                MiscEquipment.Sum(x => x.Value.Weight) +
                EquipedArtifacts.Sum(x => x.Value.Weight);

            return wt;
        }

        [Obsolete]
        public void EquipWeapon(Item weapon)
        {
            var bothHands = WeaponSlots.OffHand | WeaponSlots.PrimaryHand;

            if (weapon.WeaponLocation == bothHands)
            {
                UnEquipWeapon(WeaponSlots.OffHand);
                UnEquipWeapon(WeaponSlots.PrimaryHand);
            }
            else if (EquipedWeapons.ContainsKey(bothHands))
                UnEquipWeapon(bothHands);
            else if (EquipedWeapons.ContainsKey(weapon.WeaponLocation))
                UnEquipWeapon(weapon);

            weapon.IsEquiped = true;
            EquipedWeapons.Add(weapon.WeaponLocation, (Weapon)weapon);
        }

        [Obsolete]
        public void UnEquipWeapon(Item weapon)
        {
            weapon.IsEquiped = false;

            if (EquipedWeapons.ContainsKey(weapon.WeaponLocation))
            {
                Items.Add(weapon);
                EquipedWeapons.Remove(weapon.WeaponLocation);
            }
        }
    }
}
