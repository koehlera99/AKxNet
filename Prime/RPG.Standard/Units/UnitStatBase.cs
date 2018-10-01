using RPG.Standard.Base;
using RPG.Standard.Stats;
using RPG.Standard.Units.UnitClass;

namespace RPG.Standard.Units
{
    public abstract class StatBase : Object
    {
        private ClassBase Class = new ClassBase();

        protected MajorStats Major { get; private set; }
        protected PrimaryStats Primary { get; private set; }
        protected SecondaryStats Secondary { get; private set; }
        protected DefenseStats Defense { get; private set; }
        protected ArcaneElementStats ElementDefense { get; private set; }
        protected ArmorTypeStats ArmorTypes { get; private set; }
        protected WeaponDamageTypeStats WeaponTypes { get; private set; }

        public Condition Conditions { get; private set; }
        public Level UnitLevel;

        public StatBase()
        {
            Initialize();
        }

        public StatBase(int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType, int[] weaponType)
        {
            Initialize(primary, secondary, defense, element, armorType, weaponType);
        }

        public void SetAllStats(int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType, int[] weaponType)
        {
            Primary.SetAll(primary);
            Secondary.SetAll(secondary);
            Defense.SetAll(defense);
            ElementDefense.SetAll(element);
            ArmorTypes.SetAll(armorType);
            WeaponTypes.SetAll(weaponType);

            Major.SetAll
            (
                new int[]
                {
                    (
                        Secondary.Stats[SecondaryFlag.Vitality].Value *
                        Primary.Stats[PrimaryFlag.Con].Value *
                        UnitLevel.Value
                    ),
                    (
                        Primary.Stats[PrimaryFlag.Str].Value +
                        Primary.Stats[PrimaryFlag.Dex].Value +
                        Primary.Stats[PrimaryFlag.Con].Value +
                        PowerBonus()
                    ),
                    (
                        Primary.Stats[PrimaryFlag.Int].Value +
                        Primary.Stats[PrimaryFlag.Wis].Value +
                        Primary.Stats[PrimaryFlag.Cha].Value +
                        MagicBonus()
                    )
                }
            );
        }

        protected int PowerBonus()
        {
            int bonus = 0;

            if ((Class.PrimaryStat & PrimaryStats.PowerBonusStats) != 0)
            {
                bonus += Primary.Stats[Class.PrimaryStat].Value * UnitLevel.Value * 2;
            }

            if ((Class.SecondaryStat & PrimaryStats.PowerBonusStats) != 0)
            {
                bonus += Primary.Stats[Class.SecondaryStat].Value * UnitLevel.Value;
            }

            return bonus;
        }

        protected int MagicBonus()
        {
            int bonus = 0;

            if ((Class.PrimaryStat & PrimaryStats.MagicBonusStats) != 0)
            {
                bonus += Primary.Stats[Class.PrimaryStat].Value * UnitLevel.Value * 2;
            }

            if ((Class.SecondaryStat & PrimaryStats.MagicBonusStats) != 0)
            {
                bonus += Primary.Stats[Class.PrimaryStat].Value * UnitLevel.Value;
            }

            return bonus;
        }

        public void AddCondition(Condition stat) { Conditions = Conditions | stat; }

        public void RemoveCondition(Condition stat)
        {
            if ((Conditions & stat) == stat)
            {
                Conditions ^= stat;
            }
        }

        public int GreaterOf(Stat stat1, Stat stat2)
        {
            if (stat1.Value > stat2.Value)
                return stat1.Value;
            else
                return stat2.Value;
        }

        private void Initialize()
        {
            UnitLevel = new Level(200);

            Conditions = Condition.None;

            Primary = new PrimaryStats();
            Secondary = new SecondaryStats();
            Defense = new DefenseStats();
            ElementDefense = new ArcaneElementStats();
            ArmorTypes = new ArmorTypeStats();
            WeaponTypes = new WeaponDamageTypeStats();

            SetMajorStats();
        }

        private void Initialize(int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType, int[] weaponType)
        {
            UnitLevel = new Level(200);

            Conditions = Condition.None;

            Primary = new PrimaryStats(primary);
            Secondary = new SecondaryStats(secondary);
            Defense = new DefenseStats(defense);
            ElementDefense = new ArcaneElementStats(element);
            ArmorTypes = new ArmorTypeStats(armorType);
            WeaponTypes = new WeaponDamageTypeStats(weaponType);

            SetMajorStats();
        }

        private void SetMajorStats()
        {
            Major = new MajorStats
            (
                new int[]
                {
                    (
                        Secondary.Stats[SecondaryFlag.Vitality].Value * 
                        Primary.Stats[PrimaryFlag.Con].Value * 
                        UnitLevel.Value
                    ),
                    (
                        Primary.Stats[PrimaryFlag.Str].Value + 
                        Primary.Stats[PrimaryFlag.Dex].Value + 
                        Primary.Stats[PrimaryFlag.Con].Value + 
                        PowerBonus()
                    ),
                    (
                        Primary.Stats[PrimaryFlag.Int].Value + 
                        Primary.Stats[PrimaryFlag.Wis].Value + 
                        Primary.Stats[PrimaryFlag.Cha].Value + 
                        MagicBonus()
                    ),

                    0
                }
            );
        }
    }
}




//protected Dictionary<Primary, Stat> PrimaryStats { get; } = new Dictionary<Primary, Stat>();
//protected Dictionary<Secondary.Flag, Stat> SecondaryStats { get; } = new Dictionary<Secondary.Flag, Stat>();
//protected Dictionary<Defense.Flag, Stat> DefenseStats { get; } = new Dictionary<Defense.Flag, Stat>();
//protected Dictionary<Element.Flag, Stat> ElementDefense { get; } = new Dictionary<Element.Flag, Stat>();
//protected Dictionary<ArmorType.Flag, Stat> ArmorTypes { get; } = new Dictionary<ArmorType.Flag, Stat>();
//protected Dictionary<WeaponType.Flag, Stat> WeaponTypes { get; } = new Dictionary<WeaponType.Flag, Stat>();

//protected Stat Get(Major stat) { return MajorStats[stat]; }
//protected Stat Get(Primary stat) { return _primaryStats[stat]; }
//protected Stat Get(Secondary stat) { return _secondaryStats[stat]; }
//protected Stat Get(Defense stat) { return _defenseStats[stat]; }
//protected Stat Get(Element stat) { return _elementDefense[stat]; }
//protected Stat Get(ArmorType stat) { return _armorTypes[stat]; }

//public void Set(Major stat, int value) { _majorStats[stat].Set(value); }
//public void Set(Primary stat, int value) { _primaryStats[stat].Set(value); }
//public void Set(Secondary stat, int value) { _secondaryStats[stat].Set(value); }
//public void Set(Defense stat, int value) { _defenseStats[stat].Set(value); }
//public void Set(Element stat, int value) { _elementDefense[stat].Set(value); }
//public void Set(ArmorType stat, int value) { _armorTypes[stat].Set(value); }

//public void Adjust(Major stat, int value) { _majorStats[stat].Adjust(value); }
//public void Adjust(Primary stat, int value) { _primaryStats[stat].Adjust(value); }
//public void Adjust(Secondary stat, int value) { _secondaryStats[stat].Adjust(value); }
//public void Adjust(Defense stat, int value) { _defenseStats[stat].Adjust(value); }
//public void Adjust(Element stat, int value) { _elementDefense[stat].Adjust(value); }
//public void Adjust(ArmorType stat, int value) { _armorTypes[stat].Adjust(value); }

//private void SetPrimaryStats()
//{
//    foreach (Primary.Flag primary in (Primary.Flag[])Enum.GetValues(typeof(Primary.Flag)))
//    {
//        PrimaryStats.Stats.Add(primary, new Stat());
//    }
//}

//private void SetSecondaryStats()
//{
//    foreach (Secondary.Flag secondary in (Secondary.Flag[])Enum.GetValues(typeof(Secondary.Flag)))
//    {
//        SecondaryStats.Add(secondary, new Stat());
//    }
//}

//private void SetDefenseStats()
//{
//    foreach (Defense.Flag defense in (Defense.Flag[])Enum.GetValues(typeof(Defense.Flag)))
//    {
//        DefenseStats.Add(defense, new Stat());
//    }
//}

//private void SetElementStats()
//{
//    foreach (Element.Flag element in (Element.Flag[])Enum.GetValues(typeof(Element.Flag)))
//    {
//        ElementDefense.Add(element, new Stat());
//    }
//}

//private void SetArmorStats()
//{
//    foreach (ArmorType.Flag armorType in (ArmorType.Flag[])Enum.GetValues(typeof(ArmorType.Flag)))
//    {
//        ArmorTypes.Add(armorType, new Stat());
//    }
//}

//private void SetWeaponStats()
//{
//    foreach (WeaponType.Flag armorType in (WeaponType.Flag[])Enum.GetValues(typeof(WeaponType.Flag)))
//    {
//        WeaponTypes.Add(armorType, new Stat());
//    }
//}

//private void SetPrimaryStats(int[] values)
//{
//    if (Enum.GetValues(typeof(Primary.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"Primary stats should contain {Enum.GetValues(typeof(Primary.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (Primary.Flag primary in (Primary.Flag[])Enum.GetValues(typeof(Primary.Flag)))
//    {
//        PrimaryStats.Stats.Add(primary, new Stat(values[i]));

//        i++;
//    }
//}

//private void SetSecondaryStats(int[] values)
//{
//    if (Enum.GetValues(typeof(Secondary.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"Secondary stats should contain {Enum.GetValues(typeof(Secondary.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (Secondary.Flag secondary in (Secondary.Flag[])Enum.GetValues(typeof(Secondary.Flag)))
//    {
//        SecondaryStats.Add(secondary, new Stat(values[i]));

//        i++;
//    }
//}

//private void SetDefenseStats(int[] values)
//{
//    if (Enum.GetValues(typeof(Defense.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"Defense stats should contain {Enum.GetValues(typeof(Defense.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (Defense.Flag defense in (Defense.Flag[])Enum.GetValues(typeof(Defense.Flag)))
//    {
//        DefenseStats.Add(defense, new Stat(values[i]));

//        i++;
//    }
//}

//private void SetElementStats(int[] values)
//{
//    if (Enum.GetValues(typeof(Element.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"Element stats should contain {Enum.GetValues(typeof(Element.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (Element.Flag element in (Element.Flag[])Enum.GetValues(typeof(Element.Flag)))
//    {
//        ElementDefense.Add(element, new Stat(values[i]));

//        i++;
//    }
//}

//private void SetArmorStats(int[] values)
//{
//    if (Enum.GetValues(typeof(ArmorType.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"ArmorType stats should contain {Enum.GetValues(typeof(ArmorType.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (ArmorType.Flag armorType in (ArmorType.Flag[])Enum.GetValues(typeof(ArmorType.Flag)))
//    {
//        ArmorTypes.Add(armorType, new Stat(values[i]));

//        i++;
//    }
//}

//private void SetWeaponStats(int[] values)
//{
//    if (Enum.GetValues(typeof(WeaponType.Flag)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"ArmorType stats should contain {Enum.GetValues(typeof(WeaponType.Flag)).Length} itmes.");
//    }

//    int i = 0;

//    foreach (WeaponType.Flag armorType in (WeaponType.Flag[])Enum.GetValues(typeof(WeaponType.Flag)))
//    {
//        WeaponTypes.Add(armorType, new Stat(values[i]));

//        i++;
//    }
//}

//
//private void SetMajorStats()
//{
//    foreach (MajorEnum major in (MajorEnum[])Enum.GetValues(typeof(MajorEnum)))
//    {
//        MajorStats.Add(major, new Stat());
//    }
//}

//private void SetMajorStats(int[] values)
//{
//    if (Enum.GetValues(typeof(MajorEnum)).Length != values.Length)
//    {
//        throw new IndexOutOfRangeException($"Major stats should contain {Enum.GetValues(typeof(MajorEnum)).Length} itmes.");
//    }

//    MajorStats.Add(MajorEnum.HP, new Stat(values[0], SecondaryStats.Stats[SecondaryStats.Flag.Vitality].Value * PrimaryStats.Stats[PrimaryStatsFlag.Con].Value * UnitLevel.Value));
//    MajorStats.Add(MajorEnum.Power, new Stat(values[1], PrimaryStats.Stats[PrimaryStatsFlag.Str].Value + PrimaryStats.Stats[PrimaryStatsFlag.Dex].Value + PrimaryStats.Stats[PrimaryStatsFlag.Con].Value + PowerBonus()));
//    MajorStats.Add(MajorEnum.Magic, new Stat(values[2], PrimaryStats.Stats[PrimaryStatsFlag.Int].Value + PrimaryStats.Stats[PrimaryStatsFlag.Wis].Value + PrimaryStats.Stats[PrimaryStatsFlag.Cha].Value + MagicBonus()));
//    MajorStats.Add(MajorEnum.Energy, new Stat(values[3], values[3]));

//}