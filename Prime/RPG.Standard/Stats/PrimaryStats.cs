using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class PrimaryStats
    {
        public Dictionary<PrimaryFlag, Stat> Stats { get; }

        public const PrimaryFlag PowerBonusStats = PrimaryFlag.Str | PrimaryFlag.Dex | PrimaryFlag.Con;
        public const PrimaryFlag MagicBonusStats = PrimaryFlag.Int | PrimaryFlag.Wis | PrimaryFlag.Cha;

        public PrimaryStats()
        {
            Stats = new Dictionary<PrimaryFlag, Stat>();

            Set();
        }

        public PrimaryStats(int[] values)
        {
            Stats = new Dictionary<PrimaryFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(PrimaryFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Primary stats should contain {Enum.GetValues(typeof(PrimaryFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (PrimaryFlag flag in (PrimaryFlag[])Enum.GetValues(typeof(PrimaryFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (PrimaryFlag flag in (PrimaryFlag[])Enum.GetValues(typeof(PrimaryFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(PrimaryFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Primary stats should contain {Enum.GetValues(typeof(PrimaryFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (PrimaryFlag flag in (PrimaryFlag[])Enum.GetValues(typeof(PrimaryFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    [Flags]
    public enum PrimaryFlag
    {
        Str = 1,
        Dex = 2,
        Con = 4,
        Int = 8,
        Wis = 16,
        Cha = 32
    }
}
