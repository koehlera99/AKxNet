using RPG.Standard.Base;
using RPG.Standard.Base.Stats;
using System;
using System.Collections.Generic;
using RPG.Standard.Units.Classes;

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

        private Class _class;

        protected int PowerBonus()
        {
            int bonus = 0;

            if(_class.PrimaryStat == (Primary.Str | Primary.Dex | Primary.Con))
            {
                bonus += Get(_class.PrimaryStat) * 2;
            }

            if (_class.SecondaryStat == (Primary.Str | Primary.Dex | Primary.Con))
            {
                bonus += Get(_class.SecondaryStat);
            }

            return bonus;
        }

        protected int MagicBonus()
        {
            int bonus = 0;

            if (_class.PrimaryStat == (Primary.Int | Primary.Wis | Primary.Cha))
            {
                bonus += Get(_class.PrimaryStat) * 2;
            }

            if (_class.SecondaryStat == (Primary.Int | Primary.Wis | Primary.Cha))
            {
                bonus += Get(_class.SecondaryStat);
            }

            return bonus;
        }

        public Condition Conditions { get; private set; }

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

        protected int Get(Major stat) { return _majorStats[stat].Value; }
        protected int Get(Primary stat) { return _primaryStats[stat].Value; }
        protected int Get(Secondary stat) { return _secondaryStats[stat].Value; }
        protected int Get(Defense stat) { return _defenseStats[stat].Value; }
        protected int Get(Element stat) { return _elementDefense[stat].Value; }
        protected int Get(ArmorType stat) { return _armorTypes[stat].Value; }

        public void Set(Major stat, int value) { _majorStats[stat].Set(value); }
        public void Set(Primary stat, int value) { _primaryStats[stat].Set(value); }
        public void Set(Secondary stat, int value) { _secondaryStats[stat].Set(value); }
        public void Set(Defense stat, int value) { _defenseStats[stat].Set(value); }
        public void Set(Element stat, int value) { _elementDefense[stat].Set(value); }
        public void Set(ArmorType stat, int value) { _armorTypes[stat].Set(value); }
        public void Set(Condition stat) { Conditions = Conditions | stat; }

        public void Remove(Condition stat)
        {
            if ((Conditions & stat) == stat)
            {
                Conditions ^= stat;
            }
        }

        public void Adjust(Major stat, int value) { _majorStats[stat].Adjust(value); }
        public void Adjust(Primary stat, int value) { _primaryStats[stat].Adjust(value); }
        public void Adjust(Secondary stat, int value) { _secondaryStats[stat].Adjust(value); }
        public void Adjust(Defense stat, int value) { _defenseStats[stat].Adjust(value); }
        public void Adjust(Element stat, int value) { _elementDefense[stat].Adjust(value); }
        public void Adjust(ArmorType stat, int value) { _armorTypes[stat].Adjust(value); }

        public int GreaterOf(Primary stat1, Primary stat2)
        {
            if (_primaryStats[stat1].Value > _primaryStats[stat2].Value)
                return _primaryStats[stat1].Value;
            else
                return _primaryStats[stat2].Value;
        }

        public int GreaterOf(Secondary stat1, Secondary stat2)
        {
            if (_secondaryStats[stat1].Value > _secondaryStats[stat2].Value)
                return _secondaryStats[stat1].Value;
            else
                return _secondaryStats[stat2].Value;
        }

        private void Initialize()
        {
            Conditions = Condition.None;

            SetMajorStats();
            SetPrimaryStats();
            SetSecondaryStats();
            SetDefenseStats();
            SetElementStats();
            SetArmorStats();
        }

        private void Initialize(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType)
        {
            Conditions = Condition.None;

            SetMajorStats(major);
            SetPrimaryStats(primary);
            SetSecondaryStats(secondary);
            SetDefenseStats(defense);
            SetElementStats(element);
            SetArmorStats(armorType);
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

            foreach (Major major in (Major[])Enum.GetValues(typeof(Major)))
            {
                _majorStats.Add(major, new Stat(values[i]));

                i++;
            }
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
