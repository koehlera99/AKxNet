using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class ArcaneElementStats
    {
        private const int _maxValue = 200;

        public Dictionary<ArcaneElementFlag, Stat> Stats { get; }

        public ArcaneElementStats()
        {
            Stats = new Dictionary<ArcaneElementFlag, Stat>();

            Set();
        }

        public ArcaneElementStats(int[] values)
        {
            Stats = new Dictionary<ArcaneElementFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(ArcaneElementFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Element stats should contain {Enum.GetValues(typeof(ArcaneElementFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (ArcaneElementFlag flag in (ArcaneElementFlag[])Enum.GetValues(typeof(ArcaneElementFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (ArcaneElementFlag flag in (ArcaneElementFlag[])Enum.GetValues(typeof(ArcaneElementFlag)))
            {
                Stats.Add(flag, new Stat(0, _maxValue));
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(ArcaneElementFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Element stats should contain {Enum.GetValues(typeof(ArcaneElementFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (ArcaneElementFlag flag in (ArcaneElementFlag[])Enum.GetValues(typeof(ArcaneElementFlag)))
            {
                Stats.Add(flag, new Stat(values[i++], _maxValue));
            }
        }
    }

    [Flags]
    public enum ArcaneElementFlag
    {
        Air = 1,
        Ice = 2,
        Water = 4,
        Poison = 8,
        Earth = 16,
        Acid = 32,
        Fire = 64,
        Thunder = 128,
        Electric = 256,
        Radiant = 512,
        Psionic = 1024,
        Shadow = 2048,
        Force = 4096
    }
}
