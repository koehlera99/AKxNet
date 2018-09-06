using RPG.Standard.Base;
using RPG.Standard.Base.Stats;
using RPG.Standard.Combat;
using RPG.Standard.Effects;
using RPG.Standard.Items;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using RPG.Standard.Tools;
using RPG.Standard.Worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RPG.Standard.Units
{
    /// <summary>
    /// Properties of a typical Unit
    /// </summary>
    public partial class Unit : UnitStats, ISectionItem
    {
        #region Stats
        //Primary Stats
        //private int _strength = 10;
        //private int _dexterity = 10;
        //private int _constitution = 10;
        //private int _intelligence = 10;
        //private int _wisdom = 10;
        //private int _charisma = 10;

        //Secondary Stats
        //private int _stamina;
        //private int _accuracy;
        //private int _reflex;
        //private int _vitality;
        //private int _endurance;
        //private int _attunement;
        //private int _faith;
        //private int _will;
        //private int _luck;
        #endregion

        //#region Proficiencis
        ////Damage Proficiencies
        //private int _slashingWeapons;
        //private int _bluntWeapons;
        //private int _PiercingWeapons;

        ////Weapon ArmorType Proficiences
        //private int _throwing;
        //private int _martial;
        //private int _twoHanded;
        //private int _lightRanged;
        //private int _twoHandedRanged;

        ////EquipedArmor ArmorType Proficiences
        //private int _clothArmor;
        //private int _chainMail;
        //private int _ringMail;
        //private int _scaleMail;
        //private int _plateMail;
        //private int _shields;
        //#endregion

        private int _level = 0;
        private long _experience = 0;
        private int _hitpoints = 0;

        //private int _power;
        //private int _magic;
        //private int _energy;

        //private int _dodgeChance;
        //private int _criticalChance;

        private int _speed;
        private const int bonusCalcAdj = 11;


        //Constructors
        public Unit() { }

        public bool Attack(Unit defender)
        {
            return Roll.AttackRoll(AttackBonus()) >= defender.ArmorClass;
        }

        public bool Attack(Unit defender, Weapon weapon)
        {
            //old :: replace with new
            return Roll.AttackRoll(AttackBonus(weapon)) >= defender.ArmorClass;
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

        public static bool Search() => throw new NotImplementedException();
        public static bool CastSpell() => throw new NotImplementedException();
        public static bool UseSpecialPower() => throw new NotImplementedException();
        public static bool Move() => throw new NotImplementedException();
        public static bool UseItem() => throw new NotImplementedException();

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

        //Get all buffs for selected stat
        [DebuggerStepThrough]
        public int Effects(string name)
        {
            RefreshEffects();

            return CurrentEffects.Where(x => x.Name.ToUpper() == name.ToUpper()).Sum(x => x.Value);
        }

        public float GetWeightCarried()
        {
            float wt = 
                Items.Sum(x => x.Weight) +
                EquipedWeapons.Sum(x => x.Value.Weight) +
                EquipedArmor.Sum(x => x.Value.Weight) +
                MiscEquipment.Sum(x => x.Value.Weight) +
                EquipedArtifacts.Sum(x => x.Value.Weight);

            if (wt > MaxCarryCapacity)
                OverLoadedWithWeight = true;
            else
                OverLoadedWithWeight = false;

            return wt;
        }

        private void RefreshItems()
        {
            WeightCarried = GetWeightCarried();
        }

        //Set a buff and return its unique name
        public string AddEffect(string name, int value, string desc, string source, int ttl)
        {
            CurrentEffects.Add(new Effect(name, value, desc, source, ttl));
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        //Set a buff and return its unique name
        public string AddEffect(Effect effect)
        {
            CurrentEffects.Add(effect);
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        public void RefreshEffects()
        {
            if (CurrentEffects == null)
                CurrentEffects = new List<Effect>();

            foreach (Effect e in CurrentEffects)
                e.Refresh();

            CurrentEffects.RemoveAll(CurrentEffects => CurrentEffects.IsActive == false);
        }

        //Get all buffs for selected stat
        public int GetResistanceValue(Damage damage)
        {
            //int resistance = DamagResistances.Where(x => x.DamageType == damage.DamageType | x.DamageTypeName = damage.DamageTypeName).Sum(x => x.;
            return 6; // resistance + Effects(damage.DamageTypeName) + Effects(damage.DamageType.ToString());
        }

        //Get all buffs for selected stat
        public int GetResistanceValue(DamageType damageType)
        {
            int resistance = DamagResistances.Where(x => x.DamageType == damageType).Sum(x => x.Value);
            return resistance + Effects(damageType.ToString());
        }

        //Get all buffs for selected stat
        public int GetResistanceValue(string damageTypeName)
        {
            int resistance = DamagResistances.Where(x => x.DamageTypeName == damageTypeName).Sum(x => x.Value);
            return resistance + Effects(damageTypeName);
        }

        public DamageBlob DealDamage(Weapon weapon)
        {
            return new DamageBlob(weapon.DealDamage(StrengthBonus));
        }

        public int TakeDamage(DamageBlob damageBlob)
        {
            int damageTaken;
            ApplyResistanceToDamage(damageBlob);
            damageTaken = ApplyDamage(damageBlob);

            return damageTaken;
        }

        public int ApplyResistanceToDamage(DamageBlob damageBlob)
        {
            int totalDamage = 0;

            foreach (Damage d in damageBlob.DamageList)
            {
                d.AmountResisted = GetResistanceValue(d);
                totalDamage += d.DamageAfterResistance;
            }

            return totalDamage;
        }

        public int ApplyDamage(DamageBlob damageBlob)
        {
            int damageTaken = 0;

            foreach (Damage d in damageBlob.DamageList)
            {
                HitPoints -= d.DamageAfterResistance;
                damageTaken += d.DamageAfterResistance;
            }

            return damageTaken;
        }

        public int ApplyDamage(int damageValue)
        {
            HitPoints -= damageValue;
            return damageValue;
        }

        public int GetBaseStatBonus(Primary stat)
        {
            switch (stat)
            {
                case Primary.Str:
                    return StrengthBonus;
                case Primary.Dex:
                    return DexterityBonus;
                case Primary.Con:
                    return ConstitutionBonus;
                case Primary.Int:
                    return IntelligenceBonus;
                case Primary.Wis:
                    return WisdomBonus;
                case Primary.Cha:
                    return CharismaBonus;
                default:
                    return 0;
            }
        }

        #region Base Stat Bonuses
        /// <summary>
        /// Primary Stat Bonuses
        /// </summary>
        public Guid SectionId { get; set; }

        public int StrengthBonus { get { return (Strength - bonusCalcAdj) / 2; } }
        public int DexterityBonus { get { return (Dexterity - bonusCalcAdj) / 2; } }
        public int ConstitutionBonus { get { return (Constitution - bonusCalcAdj) / 2; } }

        public int IntelligenceBonus { get { return (Intelligence - bonusCalcAdj) / 2; } }
        public int WisdomBonus { get { return (Wisdom - bonusCalcAdj) / 2; } }
        public int CharismaBonus { get { return (Charisma - bonusCalcAdj) / 2; } }

        #endregion

        #region Base Stats
        /// <summary>
        /// Primary Stats
        /// </summary>

        //public int Strength
        //{
        //    get { return Str + Effects("Str"); }
        //}
        //public int Dexterity
        //{
        //    get { return Dex + Effects("Dex"); }
        //}
        //public int Constitution
        //{
        //    get { return Con + Effects("Con"); }
        //}
        //public int Intelligence
        //{
        //    get { return Int + Effects("Int"); }
        //}
        //public int Wisdom
        //{
        //    get { return Wis + Effects("Wis"); }
        //}
        //public int Charisma
        //{
        //    get { return Cha + Effects("Cha"); }
        //}

        #endregion

        #region Secondary Stats
        /// <summary>
        /// Secondary Stats
        /// </summary>
        //public int Stamina
        //{
        //    get { return _stamina + StrengthBonus + Effects("Stamina"); }
        //    set { _stamina = value; }
        //}

        //public int Accuracy
        //{
        //    get { return _accuracy + DexterityBonus + Effects("Accuracy"); }
        //    set { _accuracy = value; }
        //}

        //public int Reflex
        //{
        //    get { return _reflex + DexterityBonus + Effects("Reflex"); }
        //    set { _reflex = value; }
        //}

        //public int Vitality
        //{
        //    get { return _vitality + ConstitutionBonus + Effects("Vitality"); }
        //    set { _vitality = value; }
        //}

        //public int Endurance
        //{
        //    get { return _endurance + ConstitutionBonus + Effects("Endurance"); }
        //    set { _endurance = value; }
        //}

        //public int Attunement
        //{
        //    get { return _attunement + IntelligenceBonus + Effects("Attunement"); }
        //    set { _attunement = value; }
        //}

        //public int Faith
        //{
        //    get { return _faith + WisdomBonus + Effects("Faith"); }
        //    set { _faith = value; }
        //}

        //public int Will
        //{
        //    get { return _will + WisdomBonus + Effects("Will"); }
        //    set { _will = value; }
        //}

        //public int Luck
        //{
        //    get { return _luck + CharismaBonus + Effects("Luck"); }
        //    set { _luck = value; }
        //}

        #endregion

        public string UnitName { get; set; }

        public List<Effect> CurrentEffects { get; set; } = new List<Effect>();
        public int CriticalMultiplier { get; set; }

        private int LevelAttackBonus { get { return (Level / 10) + 1; } }
        private int ClassAttackBonsus { get; set; }
        public short HitDice { get; set; }

        public int Speed
        {
            get { return _speed + Effects("Speed"); }
            set { _speed = value; }
        }

        public bool IsDead
        {
            get { return HitPoints == 0; }
        }

        public bool OverLoadedWithWeight { get; private set; } = false;
        public float WeightCarried { get; private set; }

        protected List<Property> UnitProperties { get; set; } = new List<Property>();
        protected List<Item> Items { get; set; } = new List<Item>();
        protected List<DamageResistance> DamagResistances { get; set; } = new List<DamageResistance>();

        public Dictionary<WeaponSlots, Weapon> EquipedWeapons { get; set; } = new Dictionary<WeaponSlots, Weapon>();
        public Dictionary<ArmorSlots, Armor> EquipedArmor { get; set; } = new Dictionary<ArmorSlots, Armor>();
        public Dictionary<MiscSlots, EquipableItem> MiscEquipment { get; set; } = new Dictionary<MiscSlots, EquipableItem>();
        public Dictionary<ArtifactSlots, Artifact> EquipedArtifacts { get; set; } = new Dictionary<ArtifactSlots, Artifact>();

        //public Dictionary<EquipmentSlot, Item> EquipedItems { get; set; } = new Dictionary<EquipmentSlot, Item>();
        //public Dictionary<RingSlots, Item> EquipedRings { get; set; } = new Dictionary<RingSlots, Item>();

        #region Proficiencies
        /// <summary>
        /// Damage ArmorType Proficiencies
        /// </summary>
        public int SlashingWeapons { get; set; }
        public int BluntWeapons { get; set; }
        public int PiercingWeapons { get; set; }


        ///// <summary>
        ///// Weapon ArmorType Proficiences
        ///// </summary>
        //public int Throwing { get; set; }
        //public int Martial { get; set; }
        //public int TwoHanded { get; set; }
        //public int LightRanged { get; set; }
        //public int TwoHandedRanged { get; set; }

        ///// <summary>
        ///// EquipedArmor ArmorType Proficiencies
        ///// </summary>
        //public int ClothArmor { get; set; }
        //public int ChainMail { get; set; }
        //public int RingMail { get; set; }
        //public int ScaleMail { get; set; }
        //public int PlateMail { get; set; }
        //public int Shields { get; set; }

        #endregion

        //Calculated Properties
        public int AttackBonus()
        {
            return AttackBonus(EquipedWeapons[WeaponSlots.PrimaryHand]);
        }

        public int AttackBonus(Weapon weapon)
        {
            return LevelAttackBonus + ClassAttackBonsus + weapon.AttackBonus + GetBaseStatBonus(weapon.PrimaryWeaponStat) + Effects("AttackBonus");
        }

        public int MaxCarryCapacity
        {
            get { return Strength * 10 + Effects("MaxCarryCapacity"); }
        }

        public int Level
        {
            get { return _level + Effects("Level"); }
        }

        public long Experience
        {
            get { return _experience; }
            set
            {
                _experience += value + (value * (Effects("Experience") / 100));

                while (_experience >= LevelTable.GetNextLevelXP(_level))
                {
                    _level += 1;
                    _hitpoints = MaxHitPoints;
                }
            }
        }

        public int HitPoints
        {
            get { return _hitpoints + Effects("HitPoints"); }
            set
            {
                _hitpoints = (value > MaxHitPoints) ? MaxHitPoints : value;

                if (_hitpoints < 0)
                    _hitpoints = 0;
            }
        }

        public int DamageTaken
        {
            get { return MaxHitPoints - HitPoints; }
        }

        //public int Magic
        //{
        //    get { return _magic; }
        //    set { _magic = (value > MaxMagic ? MaxMagic : value); }
        //}

        //public int Power
        //{
        //    get { return _power; }
        //    set { _power = (value > MaxPower ? MaxPower : value); }
        //}

        //public int Energy
        //{
        //    get { return _energy; }
        //    set { _energy = (value > MaxEnergy ? MaxEnergy : value); }
        //}

        public int MaxHitPoints
        {
            get { return (_level * (HitDice + ConstitutionBonus) * (1 + (Effects("HitPoints") / 100))); }
        }

        public int MaxMagic
        {
            get { return Charisma * Wisdom * Intelligence + Effects("Magic"); }
        }

        public int MaxPower
        {
            get { return Strength * Dexterity * Constitution + Effects("Power"); }
        }

        public int MaxEnergy
        {
            get
            {
                int energy =
                    EquipedWeapons.Sum(x => x.Value.Energy) +
                    EquipedArmor.Sum(x => x.Value.Energy) +
                    MiscEquipment.Sum(x => x.Value.Energy) +
                    EquipedArtifacts.Sum(x => x.Value.Energy);


                energy += Effects("Energy");
                return energy + 10;
                //return energy;
            }
        }

        //public int DodgeChance
        //{
        //    get { return _dodgeChance + Effects("DodgeChance"); }
        //    set { _dodgeChance = value; }
        //}

        //public int CriticalChance
        //{
        //    get { return _criticalChance + Effects("Critical"); }
        //    set { _criticalChance = value; }
        //}

        //EquipedArmor Class
        public int ArmorClass
        {
            get
            {
                int armor =
                    EquipedWeapons.Sum(x => x.Value.DefenseBonus) +
                    EquipedArmor.Sum(x => x.Value.ArmorClass);

                return armor + DexterityBonus - ArmorDexReduction + Effects("ArmorClass");
            }
        }

        //EquipedArmor Class Dexterity Reduction
        public int ArmorDexReduction
        {
            get
            {
                int dexReduction = (int)EquipedArmor.Sum(x => x.Value.MaxDexReduction);

                dexReduction += Effects("ArmorDexReduction");

                if (dexReduction > DexterityBonus)
                    dexReduction = DexterityBonus;

                return dexReduction;
            }
        }

        //Scale Mail resists blunt damage
        public int BluntResist
        {
            get
            {
                return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Scale || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue) + Effects("BluntResist");
            }
        }

        //Chain mail resists piercing damage
        public int PierceResist
        {
            get
            {
                return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Chain || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue) + Effects("PierceResist");
            }
        }

        //Ring mail resists slashing damage
        public int SlashResist
        {
            get
            {
                return EquipedArmor
                    .Where(x => x.Value.ArmorType == ArmorType.Ring || x.Value.ArmorType == ArmorType.Plate)
                    .Sum(x => x.Value.ArmorHardnessValue) + Effects("SlashResist");
            }
        }
    }
}
