using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class DefenseStats
    {
        public Dictionary<DefenseFlag, Stat> Stats { get; }

        public DefenseStats()
        {
            Stats = new Dictionary<DefenseFlag, Stat>();

            Set();
        }

        public DefenseStats(int[] values)
        {
            Stats = new Dictionary<DefenseFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(DefenseFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Defense stats should contain {Enum.GetValues(typeof(DefenseFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (DefenseFlag flag in (DefenseFlag[])Enum.GetValues(typeof(DefenseFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (DefenseFlag flag in (DefenseFlag[])Enum.GetValues(typeof(DefenseFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(DefenseFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Defense stats should contain {Enum.GetValues(typeof(DefenseFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (DefenseFlag flag in (DefenseFlag[])Enum.GetValues(typeof(DefenseFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    public enum DefenseFlag
    {
        ArmorClass,
        BlockChance,
        DodgeChance,
        ParryChance,
        BluntResist,
        PierceResist,
        SlashResist
    }
}
