using RPG.Standard.Base;
using RPG.Standard.Base.Stats;
using System;
using System.Collections.Generic;
using RPG.Standard.Units.UnitClass;

namespace RPG.Standard.Units
{
    public abstract class UnitBase : Object
    {
        private Dictionary<Major, Stat> _majorStats;
        private Dictionary<Primary, Stat> _primaryStats;
        private Dictionary<Secondary, Stat> _secondaryStats;
        private Dictionary<Defense, Stat> _defenseStats;
        private Dictionary<Element, Stat> _elementDefense;
        private Dictionary<ArmorType, Stat> _armorTypes;

        private ClassBase _class;

        protected int Speed;

        public Condition Conditions { get; private set; }
        public Level UnitLevel;

        public UnitBase()
        {
            Initialize();
        }

        public UnitBase(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType)
        {
            Initialize(major, primary, secondary, defense, element, armorType);
        }

        public void SetAllStats(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType)
        {
            SetMajorStats(major);
            SetPrimaryStats(primary);
            SetSecondaryStats(secondary);
            SetDefenseStats(defense);
            SetElementStats(element);
            SetArmorStats(armorType);
        }

        protected int PowerBonus()
        {
            int bonus = 0;

            if (_class.PrimaryStat == (Primary.Str | Primary.Dex | Primary.Con))
            {
                bonus += Get(_class.PrimaryStat).Value * 2;
            }

            if (_class.SecondaryStat == (Primary.Str | Primary.Dex | Primary.Con))
            {
                bonus += Get(_class.SecondaryStat).Value;
            }

            return bonus;
        }

        protected int MagicBonus()
        {
            int bonus = 0;

            if (_class.PrimaryStat == (Primary.Int | Primary.Wis | Primary.Cha))
            {
                bonus += Get(_class.PrimaryStat).Value * 2;
            }

            if (_class.SecondaryStat == (Primary.Int | Primary.Wis | Primary.Cha))
            {
                bonus += Get(_class.SecondaryStat).Value;
            }

            return bonus;
        }

        protected Stat Get(Major stat) { return _majorStats[stat]; }
        protected Stat Get(Primary stat) { return _primaryStats[stat]; }
        protected Stat Get(Secondary stat) { return _secondaryStats[stat]; }
        protected Stat Get(Defense stat) { return _defenseStats[stat]; }
        protected Stat Get(Element stat) { return _elementDefense[stat]; }
        protected Stat Get(ArmorType stat) { return _armorTypes[stat]; }

        //public void Set(Major stat, int value) { _majorStats[stat].Set(value); }
        //public void Set(Primary stat, int value) { _primaryStats[stat].Set(value); }
        //public void Set(Secondary stat, int value) { _secondaryStats[stat].Set(value); }
        //public void Set(Defense stat, int value) { _defenseStats[stat].Set(value); }
        //public void Set(Element stat, int value) { _elementDefense[stat].Set(value); }
        //public void Set(ArmorType stat, int value) { _armorTypes[stat].Set(value); }

        public void AddCondition(Condition stat) { Conditions = Conditions | stat; }

        public void RemoveCondition(Condition stat)
        {
            if ((Conditions & stat) == stat)
            {
                Conditions ^= stat;
            }
        }

        //public void Adjust(Major stat, int value) { _majorStats[stat].Adjust(value); }
        //public void Adjust(Primary stat, int value) { _primaryStats[stat].Adjust(value); }
        //public void Adjust(Secondary stat, int value) { _secondaryStats[stat].Adjust(value); }
        //public void Adjust(Defense stat, int value) { _defenseStats[stat].Adjust(value); }
        //public void Adjust(Element stat, int value) { _elementDefense[stat].Adjust(value); }
        //public void Adjust(ArmorType stat, int value) { _armorTypes[stat].Adjust(value); }

        public int GreaterOf(Stat stat1, Stat stat2)
        {
            if (stat1.Value > stat2.Value)
                return stat1.Value;
            else
                return stat2.Value;
        }


        private void Initialize()
        {
            Conditions = Condition.None;

            SetPrimaryStats();
            SetSecondaryStats();
            SetDefenseStats();
            SetElementStats();
            SetArmorStats();
            SetMajorStats();
        }

        private void Initialize(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType)
        {
            Conditions = Condition.None;


            SetPrimaryStats(primary);
            SetSecondaryStats(secondary);
            SetDefenseStats(defense);
            SetElementStats(element);
            SetArmorStats(armorType);
            SetMajorStats(major);
        }

        private void SetMajorStats()
        {
            _majorStats = new Dictionary<Major, Stat>();

            foreach (Major major in (Major[])Enum.GetValues(typeof(Major)))
            {
                _majorStats.Add(major, new Stat());
            }
        }

        private void SetPrimaryStats()
        {
            _primaryStats = new Dictionary<Primary, Stat>();

            foreach (Primary primary in (Primary[])Enum.GetValues(typeof(Primary)))
            {
                _primaryStats.Add(primary, new Stat());
            }
        }

        private void SetSecondaryStats()
        {
            _secondaryStats = new Dictionary<Secondary, Stat>();

            foreach (Secondary secondary in (Secondary[])Enum.GetValues(typeof(Secondary)))
            {
                _secondaryStats.Add(secondary, new Stat());
            }
        }

        private void SetDefenseStats()
        {
            _defenseStats = new Dictionary<Defense, Stat>();

            foreach (Defense defense in (Defense[])Enum.GetValues(typeof(Defense)))
            {
                _defenseStats.Add(defense, new Stat());
            }
        }

        private void SetElementStats()
        {
            _elementDefense = new Dictionary<Element, Stat>();

            foreach (Element element in (Element[])Enum.GetValues(typeof(Element)))
            {
                _elementDefense.Add(element, new Stat());
            }
        }

        private void SetArmorStats()
        {
            _armorTypes = new Dictionary<ArmorType, Stat>();

            foreach (ArmorType armorType in (ArmorType[])Enum.GetValues(typeof(ArmorType)))
            {
                _armorTypes.Add(armorType, new Stat());
            }
        }

        private void SetMajorStats(int[] values)
        {
            if (Enum.GetValues(typeof(Major)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Major stats should contain {Enum.GetValues(typeof(Major)).Length} itmes.");
            }

            int i = 0;

            _majorStats = new Dictionary<Major, Stat>();

            _majorStats.Add(Major.HP, new Stat(values[0], Get(Secondary.Vitality).Value + Get(Primary.Con).Value + UnitLevel.Value));
            _majorStats.Add(Major.Power, new Stat(values[0], Get(Primary.Str).Value + Get(Primary.Dex).Value + Get(Primary.Con).Value + PowerBonus()));
            _majorStats.Add(Major.Magic, new Stat(values[0], Get(Primary.Int).Value + Get(Primary.Wis).Value + Get(Primary.Cha).Value + MagicBonus()));
            _majorStats.Add(Major.Energy, new Stat(values[0], Get(Major.Energy).Value));

        }

        private void SetPrimaryStats(int[] values)
        {
            if (Enum.GetValues(typeof(Primary)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Primary stats should contain {Enum.GetValues(typeof(Primary)).Length} itmes.");
            }

            int i = 0;

            _primaryStats = new Dictionary<Primary, Stat>();

            foreach (Primary primary in (Primary[])Enum.GetValues(typeof(Primary)))
            {
                _primaryStats.Add(primary, new Stat(values[i]));

                i++;
            }
        }

        private void SetSecondaryStats(int[] values)
        {
            if (Enum.GetValues(typeof(Secondary)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Secondary stats should contain {Enum.GetValues(typeof(Secondary)).Length} itmes.");
            }

            int i = 0;

            _secondaryStats = new Dictionary<Secondary, Stat>();

            foreach (Secondary secondary in (Secondary[])Enum.GetValues(typeof(Secondary)))
            {
                _secondaryStats.Add(secondary, new Stat(values[i]));

                i++;
            }
        }

        private void SetDefenseStats(int[] values)
        {
            if (Enum.GetValues(typeof(Defense)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Defense stats should contain {Enum.GetValues(typeof(Defense)).Length} itmes.");
            }

            int i = 0;

            _defenseStats = new Dictionary<Defense, Stat>();

            foreach (Defense defense in (Defense[])Enum.GetValues(typeof(Defense)))
            {
                _defenseStats.Add(defense, new Stat(values[i]));

                i++;
            }
        }

        private void SetElementStats(int[] values)
        {
            if (Enum.GetValues(typeof(Element)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Element stats should contain {Enum.GetValues(typeof(Element)).Length} itmes.");
            }

            int i = 0;

            _elementDefense = new Dictionary<Element, Stat>();

            foreach (Element element in (Element[])Enum.GetValues(typeof(Element)))
            {
                _elementDefense.Add(element, new Stat(values[i]));

                i++;
            }
        }

        private void SetArmorStats(int[] values)
        {
            if (Enum.GetValues(typeof(ArmorType)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"ArmorType stats should contain {Enum.GetValues(typeof(ArmorType)).Length} itmes.");
            }

            int i = 0;

            _armorTypes = new Dictionary<ArmorType, Stat>();

            foreach (ArmorType armorType in (ArmorType[])Enum.GetValues(typeof(ArmorType)))
            {
                _armorTypes.Add(armorType, new Stat(values[i]));

                i++;
            }
        }
    }
}
