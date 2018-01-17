using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG.Core.Effects;
using RPG.Core.Items;
using RPG.Core.Items.Defense;
using RPG.Core.Items.Offense;

namespace RPG.Core.Units
{
    public partial class Unit
    {
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

        public int Strength
        {
            get { return _strength + Effects("Strength"); }
            set { _strength = value; }
        }
        public int Dexterity
        {
            get { return _dexterity + Effects("Dexterity"); }
            set { _dexterity = value; }
        }
        public int Constitution
        {
            get { return _constitution + Effects("Constitution"); }
            set { _constitution = value; }
        }
        public int Intelligence
        {
            get { return _intelligence + Effects("Intelligence"); }
            set { _intelligence = value; }
        }
        public int Wisdom
        {
            get { return _wisdom + Effects("Wisdom"); }
            set { _wisdom = value; }
        }
        public int Charisma
        {
            get { return _charisma + Effects("Charisma"); }
            set { _charisma = value; }
        }

        #endregion

        #region Secondary Stats
        /// <summary>
        /// Secondary Stats
        /// </summary>
        public int Stamina
        {
            get { return _stamina + StrengthBonus + Effects("Stamina"); }
            set { _stamina = value; }
        }

        public int Accuracy
        {
            get { return _accuracy + DexterityBonus + Effects("Accuracy"); }
            set { _accuracy = value; }
        }

        public int Reflex
        {
            get { return _reflex + DexterityBonus + Effects("Reflex"); }
            set { _reflex = value; }
        }

        public int Vitality
        {
            get { return _vitality + ConstitutionBonus + Effects("Vitality"); }
            set { _vitality = value; }
        }

        public int Endurance
        {
            get { return _endurance + ConstitutionBonus + Effects("Endurance"); }
            set { _endurance = value; }
        }

        public int Attunement
        {
            get { return _attunement + IntelligenceBonus + Effects("Attunement"); }
            set { _attunement = value; }
        }

        public int Faith
        {
            get { return _faith + WisdomBonus + Effects("Faith"); }
            set { _faith = value; }
        }

        public int Will
        {
            get { return _will + WisdomBonus + Effects("Will"); }
            set { _will = value; }
        }

        public int Luck
        {
            get { return _luck + CharismaBonus + Effects("Luck"); }
            set { _luck = value; }
        }

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


        /// <summary>
        /// Weapon ArmorType Proficiences
        /// </summary>
        public int Throwing { get; set; }
        public int Martial { get; set; }
        public int TwoHanded { get; set; }
        public int LightRanged { get; set; }
        public int TwoHandedRanged { get; set; }

        /// <summary>
        /// EquipedArmor ArmorType Proficiencies
        /// </summary>
        public int ClothArmor { get; set; }
        public int ChainMail { get; set; }
        public int RingMail { get; set; }
        public int ScaleMail { get; set; }
        public int PlateMail { get; set; }
        public int Shields { get; set; }

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

        public int Magic
        {
            get { return _magic; }
            set { _magic = (value > MaxMagic ? MaxMagic : value); }
        }

        public int Power
        {
            get { return _power; }
            set { _power = (value > MaxPower ? MaxPower : value); }
        }

        public int Energy
        {
            get { return _energy; }
            set { _energy = (value > MaxEnergy ? MaxEnergy : value); }
        }

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
                int energy = 0;

                //energy = (from e in EquipedItems select e.Value.Energy).Sum();
                energy += (from e in EquipedWeapons select e.Value.Energy).Sum();
                energy += (from e in EquipedArmor select e.Value.Energy).Sum();
                //energy += (from e in EquipedRings select e.Value.Energy).Sum();
                energy += (from e in MiscEquipment select e.Value.Energy).Sum();
                energy += (from e in EquipedArtifacts select e.Value.Energy).Sum();

                energy += Effects("Energy");
                return energy + 10;
                //return energy;
            }
        }

        public int DodgeChance
        {
            get { return _dodgeChance + Effects("DodgeChance"); }
            set { _dodgeChance = value; }
        }

        public int CriticalChance
        {
            get { return _criticalChance + Effects("Critical"); }
            set { _criticalChance = value; }
        }

        //EquipedArmor Class
        public int ArmorClass
        {
            get
            {
                int armor = 0;

                //armor = (from e in EquipedItems where e.Value.ItemType == ItemTypes.Armor select ((Armor)e.Value).ArmorClass).Sum();
                //armor += (from w in EquipedWeapons where w.Value.ItemType == ItemTypes.Armor select ((Armor)w.Value).ArmorClass).Sum();
                armor += (from w in EquipedWeapons select (w.Value).DefenseBonus).Sum();
                armor += (from a in EquipedArmor select (a.Value).ArmorClass).Sum();

                return armor + DexterityBonus - ArmorDexReduction + Effects("ArmorClass");
            }
        }

        //EquipedArmor Class Dexterity Reduction
        public int ArmorDexReduction
        {
            get
            {
                float dexReduction = 0;

                dexReduction = (from e in EquipedArmor select (e.Value).MaxDexReduction).Sum();
                dexReduction += Effects("ArmorDexReduction");

                if (dexReduction > DexterityBonus)
                    dexReduction = DexterityBonus;

                return (int)dexReduction;
            }
        }

        //Scale Mail resists blunt damage
        public int BluntResist
        {
            get
            {
                int blunt;

                blunt = (from e in EquipedArmor
                         where (e.Value).ArmorType == ArmorTypes.Scale || (e.Value).ArmorType == ArmorTypes.Plate
                         select (e.Value).ArmorHardnessValue).Sum();

                return blunt + Effects("BluntResist");
            }
        }

        //Chain mail resists piercing damage
        public int PierceResist
        {
            get
            {
                int pierce;

                pierce = (from e in EquipedArmor
                          where (e.Value).ArmorType == ArmorTypes.Chain || (e.Value).ArmorType == ArmorTypes.Plate
                          select (e.Value).ArmorHardnessValue).Sum();

                return pierce + Effects("PierceResist");
            }
        }

        //Ring mail resists slashing damage
        public int SlashResist
        {
            get
            {
                int slash;

                slash = (from e in EquipedArmor
                         where (e.Value).ArmorType == ArmorTypes.Ring || (e.Value).ArmorType == ArmorTypes.Plate
                         select (e.Value).ArmorHardnessValue).Sum();

                return slash + Effects("SlashResist");
            }
        }
    }

    #region Dead Code
    ////Melee Defense
    //public int MeleeDefense
    //{
    //    get
    //    {
    //        Random r = new Random();

    //        if (r.Next(1, 100) < DodgeChance)
    //            return ArmorClass + Effects("MeleeDefense") + DodgeBonus;
    //        else
    //            return ArmorClass + Effects("MeleeDefense");
    //    }
    //}

    ////Ranged Defense
    //public int RangedDefense
    //{
    //    get
    //    {
    //        Random r = new Random();

    //        if (r.Next(1, 100) < DodgeChance)
    //            return ArmorClass + Effects("RangedDefense") + DodgeBonus;
    //        else
    //            return ArmorClass + Effects("RangedDefense");
    //    }
    //}

    //int ac = 0;

    //foreach (var pair in EquipedItems)
    //{
    //    Item i = EquipedItems[pair.Key];

    //    if (i.ItemType == ItemTypes.EquipedArmor)
    //    {
    //        EquipedArmor a = (EquipedArmor)i;
    //        ac += a.ArmorClass;
    //    }
    //}

    //foreach (var pair in EquipedWeapons)
    //{
    //    Item i = EquipedWeapons[pair.Key];

    //    if (i.ItemType == ItemTypes.EquipedArmor)
    //    {
    //        EquipedArmor a = (EquipedArmor)i;
    //        ac += a.ArmorClass;
    //    }

    //    if (i.ItemType == ItemTypes.Weapon)
    //    {
    //        Weapon w = (Weapon)i;
    //        ac += w.DefenseBonus;
    //    }
    //}

    //struct SecondaryStats
    //{
    //    public int Vitality { get; set; }
    //    public int Endurance { get; set; }
    //    public int Luck { get; set; }
    //    public int Agility { get; set; }
    //    public int Accuracy { get; set; }
    //}

    //struct Proficiences
    //{
    //    /// <summary>
    //    /// Damage ArmorType Proficiencies
    //    /// </summary>
    //    public int SlashingWeapons { get; set; }
    //    public int BluntWeapons { get; set; }
    //    public int PiercingWeapons { get; set; }

    //    /// <summary>
    //    /// Weapon ArmorType Proficiences
    //    /// </summary>
    //    public int Throwing { get; set; }
    //    public int Martial { get; set; }
    //    public int TwoHanded { get; set; }
    //    public int LightRanged { get; set; }
    //    public int TwoHandedRanged { get; set; }

    //    /// <summary>
    //    /// EquipedArmor ArmorType Proficiencies
    //    /// </summary>
    //    public int ClothArmor { get; set; }
    //    public int ChainMail { get; set; }
    //    public int RingMail { get; set; }
    //    public int ScaleMail { get; set; }
    //    public int PlateMail { get; set; }
    //    public int Shields { get; set; }
    //}

    #endregion
}
