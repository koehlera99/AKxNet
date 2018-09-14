using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Standard.Base
{
    public class Stat : Object
    {
        private Dictionary<Guid, int> _tempValues;

        public const int MinValue = 0;
        public int MaxValue { get; private set; }
        public int BaseValue { get; private set; }
        public int Value => _tempValues.Sum(x => x.Value) + BaseValue;
        public int Bonus => Value / 10;

        public Stat()
        {
            MaxValue = 100;
            BaseValue = 0;
            _tempValues = new Dictionary<Guid, int>();
        }

        public Stat(int value)
        {
            MaxValue = 100;

            if (value > MaxValue)
                value = MaxValue;
            else if (value < MinValue)
                value = MinValue;

            BaseValue = value;
            _tempValues = new Dictionary<Guid, int>();
        }

        public Stat(int value, int maxValue)
        {
            MaxValue = maxValue;

            if (value > MaxValue)
                value = MaxValue;
            else if (value < MinValue)
                value = MinValue;

            BaseValue = value;
            _tempValues = new Dictionary<Guid, int>();
        }

        public static Stat operator +(Stat a, Stat b)
        {
            return new Stat(a.BaseValue + b.BaseValue);
        }

        public static Stat GreaterOf(Stat stat1, Stat stat2)
        {
            if (stat1.Value > stat2.Value)
                return stat1;
            else
                return stat2;
        }

        public void Set(int value)
        {
            if (value > MaxValue)
                value = MaxValue;
            else if (value < MinValue)
                value = MinValue;

            BaseValue = value;
        }

        public void Adjust(int value)
        {
            BaseValue += value;

            if (BaseValue > MaxValue)
                BaseValue = MaxValue;
            else if (BaseValue < MinValue)
                BaseValue = MinValue;
        }

        public void SetMax(int maxValue)
        {
            BaseValue += (maxValue - MaxValue);

            MaxValue = maxValue;

            if (BaseValue > MaxValue)
                BaseValue = MaxValue;
            else if (BaseValue < MinValue)
                BaseValue = MinValue;
        }

        public Guid Add(int value)
        {
            Guid id = Guid.NewGuid();

            _tempValues.Add(id, value);

            return id;
        }

        public Guid Add(int value, Guid id)
        {
            _tempValues.Add(id, value);

            return id;
        }

        public bool Remove(Guid id)
        {
            return _tempValues.Remove(id);
        }

        public void RemoveAll()
        {
            _tempValues.Clear();
        }
    }
}
