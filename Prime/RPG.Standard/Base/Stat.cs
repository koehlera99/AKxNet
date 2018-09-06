using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Standard.Base
{
    public class Stat
    {
        private const int MaxValue = 100;
        private const int MinValue = 0;
        private Dictionary<Guid, int> _tempValues;

        public int BaseValue { get; private set; }
        public int Value => _tempValues.Sum(x => x.Value) + BaseValue;

        public Stat()
        {
            BaseValue = 0;
            _tempValues = new Dictionary<Guid, int>();
        }

        public Stat(int value)
        {
            if (value > MaxValue)
                value = MaxValue;
            else if (value < MinValue)
                value = MinValue;

            BaseValue = value;
            _tempValues = new Dictionary<Guid, int>();
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
