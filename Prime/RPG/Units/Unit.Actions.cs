using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Core.Items;
using RPG.Core.Items.Defense;
using RPG.Core.Items.Offense;
using RPG.Core.Tools;

namespace RPG.Core.Units
{
    public partial class Unit
    {
        public bool Attack(Unit defender)
        {
            return Roll.AttackRoll(AttackBonus()) >= defender.ArmorClass;
        }

        public bool Attack(Unit defender, Weapon weapon)
        {
            //old :: replace with new
            return Roll.AttackRoll(AttackBonus(weapon)) >= defender.ArmorClass;
        }


        public static bool Search()
        {

            return true;
        }

        public static bool CastSpell()
        {

            return true;

        }

        public static bool UseSpecialPower()
        {

            return true;
        }

        public static bool Move()
        {

            return true;
        }

        public static bool UseItem()
        {

            return true;
        }

        /// <summary>
        /// Pass any equipable item, it will filter it to the correct equipment location
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        public void EquipArmor(Armor armor)
        {
            UnEquipArmor(armor.ArmorSlot);
            armor.IsEquiped = true;
            EquipedArmor.Add(armor.ArmorSlot, armor);
        }

        public void UnEquipArmor(ArmorSlots slot)
        {
            if (EquipedArmor.ContainsKey(slot))
            {
                EquipedArmor[slot].IsEquiped = false;
                Items.Add(EquipedArmor[slot]);
                EquipedArmor.Remove(slot);
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

        public bool EquipWeapon(Weapon weapon, WeaponSlots slot)
        {
            weapon.IsEquiped = false;
            weapon.WeaponSlot = WeaponSlots.None;

            if (slot == WeaponSlots.None)
            {
                return false;
            }
            else
            {
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
        }

        public bool EquipWeapon(Weapon weapon)
        {
            if (EquipWeapon(weapon, weapon.WeaponSlot))
            {
                return true;
            }
            else
            {
                return false;
            }
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

        //[Obsolete]
        //public void EquipItem(Item i, EquipmentSlot equipmentType)
        //{
        //    if (EquipedItems.ContainsKey(equipmentType))
        //        UnEquipItem(equipmentType);
        //    else if (equipmentType == EquipmentSlot.BothHands)
        //    {
        //        if (EquipedItems.ContainsKey(EquipmentSlot.PrimaryHand))
        //            UnEquipItem(EquipmentSlot.PrimaryHand);
        //        if (EquipedItems.ContainsKey(EquipmentSlot.OffHand))
        //            UnEquipItem(EquipmentSlot.OffHand);
        //    }
        //    else if (equipmentType == EquipmentSlot.PrimaryHand || equipmentType == EquipmentSlot.OffHand)
        //    {
        //        if (EquipedItems.ContainsKey(EquipmentSlot.BothHands))
        //            UnEquipItem(EquipmentSlot.BothHands);
        //    }

        //    i.IsEquiped = true;
        //    EquipedItems.Add(equipmentType, i);
        //}

        //[Obsolete]
        //public void UnEquipItem(Item i)
        //{
        //    i.IsEquiped = false;

        //    if (EquipedItems.ContainsKey(i.EquipLocation))
        //    {
        //        Items.Add(i);
        //        EquipedItems.Remove(i.EquipLocation);
        //    }
        //}

        //[Obsolete]
        //public void UnEquipItem(EquipmentSlot equipmentType)
        //{
        //    if (EquipedItems.ContainsKey(equipmentType))
        //    {
        //        EquipedItems[equipmentType].IsEquiped = false;
        //        Items.Add(EquipedItems[equipmentType]);
        //        EquipedItems.Remove(equipmentType);
        //    }
        //}

        //TODO: This should be an character 'Action'
        public void PickUpItem(Item item)
        {
            Items.Add(item);
            RefreshItems();
        }

        public void DropItem(string name, int quantity = 1)
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

            RefreshItems();
        }

        public void DropItem(int itemID, int quantity = 1)
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

            RefreshItems();
        }

        public void DropItem(Item item, int quantity = 1)
        {
            for (int i = quantity; i > 0; i--)
                Items.Remove(item);

            RefreshItems();
        }
    }


}
