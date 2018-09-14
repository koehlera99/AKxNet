using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class ArmorTypeStats
    {
        public Dictionary<ArmorTypeFlag, Stat> Stats { get; }

        public ArmorTypeStats()
        {
            Stats = new Dictionary<ArmorTypeFlag, Stat>();

            Set();
        }

        public ArmorTypeStats(int[] values)
        {
            Stats = new Dictionary<ArmorTypeFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(ArmorTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Armor type stats should contain {Enum.GetValues(typeof(ArmorTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (ArmorTypeFlag flag in (ArmorTypeFlag[])Enum.GetValues(typeof(ArmorTypeFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (ArmorTypeFlag flag in (ArmorTypeFlag[])Enum.GetValues(typeof(ArmorTypeFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(ArmorTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Armor type stats should contain {Enum.GetValues(typeof(ArmorTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (ArmorTypeFlag flag in (ArmorTypeFlag[])Enum.GetValues(typeof(ArmorTypeFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    public enum ArmorTypeFlag
    {
        Cloth,
        Leather,
        Chain,
        Ring,
        Scale,
        Plate,
        Shield
    }
}
