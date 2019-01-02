using RPG.Standard.Base;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using RPG.Standard.Stats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Standard.Items
{
    public class EquipmentManager
    {
        public Dictionary<WeaponSlots, Weapon> EquipedWeapons { get; }
        public Dictionary<ArmorSlots, Armor> EquipedArmor { get; }
        public Dictionary<MiscSlots, MiscEquipableItem> MiscEquipment { get; }
        public Dictionary<ArtifactSlots, Artifact> EquipedArtifacts { get; }
        public List<Item> Items { get; }

        public Weapon EquipedWeapon => EquipedWeapons[WeaponSlots.PrimaryHand];

        private int _equipedArmorClass => EquipedWeapons.Sum(x => x.Value.DefenseBonus) + EquipedArmor.Sum(x => x.Value.ArmorClass);
        private int _equipedParryChance => EquipedWeapons.Sum(x => x.Value.ParryChance);
        private int _equipedBlockChance => EquipedWeapons.Sum(x => x.Value.BlockChance);

        private int _equipedBluntResist => EquipedArmor
                    .Where(x => x.Value.ArmorTypes == ArmorTypeFlag.Scale || x.Value.ArmorTypes == ArmorTypeFlag.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);

        private int _equipedPierceResist => EquipedArmor
                    .Where(x => x.Value.ArmorTypes == ArmorTypeFlag.Chain || x.Value.ArmorTypes == ArmorTypeFlag.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);

        private int _equipedSlashResist => EquipedArmor
                    .Where(x => x.Value.ArmorTypes == ArmorTypeFlag.Ring || x.Value.ArmorTypes == ArmorTypeFlag.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue);

        private int _equipedEnergy => 
            EquipedWeapons.Sum(x => x.Value.Energy) +
            EquipedArmor.Sum(x => x.Value.Energy) +
            MiscEquipment.Sum(x => x.Value.Energy) +
            EquipedArtifacts.Sum(x => x.Value.Energy);

        public float WeightCarried =>
            Items.Sum(x => x.Weight) +
            EquipedWeapons.Sum(x => x.Value.Weight) +
            EquipedArmor.Sum(x => x.Value.Weight) +
            MiscEquipment.Sum(x => x.Value.Weight) +
            EquipedArtifacts.Sum(x => x.Value.Weight);

        public int ArmorDexReduction => (int)EquipedArmor.Sum(x => x.Value.MaxDexReduction);
        public Stat Energy { get; }

        private Stat ArmorClass, ParryChance, BlockChance, BluntResist, PierceResist, SlashResist;

        private int _unitArmorClass, _unitParryChance, _unitBlockChance, _unitBluntResist, _unitPierceResist, _unitSlashResist;

        public EquipmentManager(Stat energy, Stat bluntResist, Stat pierceResist, Stat slashResist, Stat armorClass, Stat parryChance, Stat blockChance)
        {
            Items = new List<Item>();

            EquipedWeapons = new Dictionary<WeaponSlots, Weapon>();
            EquipedArmor = new Dictionary<ArmorSlots, Armor>();
            MiscEquipment = new Dictionary<MiscSlots, MiscEquipableItem>();
            EquipedArtifacts = new Dictionary<ArtifactSlots, Artifact>();
            

            Energy = energy;

            _unitArmorClass = armorClass.Value;
            _unitParryChance = parryChance.Value;
            _unitBlockChance = blockChance.Value;

            _unitBluntResist = bluntResist.Value;
            _unitPierceResist = pierceResist.Value;
            _unitSlashResist = slashResist.Value;

            ArmorClass = armorClass;
            ParryChance = parryChance;
            BlockChance = blockChance;

            BluntResist = bluntResist;
            PierceResist = pierceResist;
            SlashResist = slashResist;

            RefreshEquipmentStats();
        }

        private void RefreshEquipmentStats()
        {
            Energy.SetMax(_equipedEnergy);

            ArmorClass.Set(_equipedArmorClass + _unitArmorClass);
            ParryChance.Set(_equipedParryChance + _unitParryChance);
            BlockChance.Set(_equipedBlockChance + _unitBlockChance);
            BluntResist.Set(_equipedBluntResist + _unitBluntResist);
            PierceResist.Set(_equipedPierceResist + _unitPierceResist);
            SlashResist.Set(_equipedSlashResist + _unitSlashResist);
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

        public void EquipMiscItem(MiscEquipableItem item)
        {
            UnEquipMiscItem(item.EquipmentSlot);
            item.IsEquiped = true;
            MiscEquipment.Add(item.EquipmentSlot, item);

            Energy.SetMax(_equipedEnergy);
        }

        public void UnEquipMiscItem(MiscSlots slot)
        {
            if (MiscEquipment.ContainsKey(slot))
            {
                MiscEquipment[slot].IsEquiped = false;
                Items.Add(MiscEquipment[slot]);
                MiscEquipment.Remove(slot);

                Energy.SetMax(_equipedEnergy);
            }
        }

        public void EquipArtifact(Artifact artifact)
        {
            UnEquipArtifact(artifact.ArtifactSlot);
            artifact.IsEquiped = true;
            EquipedArtifacts.Add(artifact.ArtifactSlot, artifact);

            Energy.SetMax(_equipedEnergy);
        }

        public void UnEquipArtifact(ArtifactSlots slot)
        {
            if (EquipedArtifacts.ContainsKey(slot))
            {
                EquipedArtifacts[slot].IsEquiped = false;
                Items.Add(EquipedArtifacts[slot]);
                EquipedArtifacts.Remove(slot);

                Energy.SetMax(_equipedEnergy);
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

            Energy.SetMax(_equipedEnergy);

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

                Energy.SetMax(_equipedEnergy);
            }
        }

        public void UnEquipWeapon(WeaponSlots weaponSlot)
        {
            if (EquipedWeapons.ContainsKey(weaponSlot))
            {
                EquipedWeapons[weaponSlot].IsEquiped = false;
                Items.Add(EquipedWeapons[weaponSlot]);
                EquipedWeapons.Remove(weaponSlot);

                Energy.SetMax(_equipedEnergy);
            }
        }

        public bool EquipItem(Item item)
        {
            if (item is Weapon)
                EquipWeapon((Weapon)item);
            else if (item is Armor)
                EquipArmor((Armor)item);
            else if (item is MiscEquipableItem)
                EquipMiscItem((MiscEquipableItem)item);
            else if (item is Artifact)
                EquipArtifact((Artifact)item);
            else
                return false;

            Energy.SetMax(_equipedEnergy);

            return true;
        }

        public float PickUpItem(Item item)
        {
            Items.Add(item);

            return WeightCarried;
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

            return WeightCarried;
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

            return WeightCarried;
        }

        public float DropItem(Item item, int quantity = 1)
        {
            for (int i = quantity; i > 0; i--)
                Items.Remove(item);

            return WeightCarried;
        }

    }
}
