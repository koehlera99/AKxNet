using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class SecondaryStats
    {
        public Dictionary<SecondaryFlag, Stat> Stats { get; } 

        public SecondaryStats()
        {
            Stats = new Dictionary<SecondaryFlag, Stat>();

            Set();
        }

        public SecondaryStats(int[] values)
        {
            Stats = new Dictionary<SecondaryFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(SecondaryFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Secondary stats should contain {Enum.GetValues(typeof(SecondaryFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (SecondaryFlag flag in (SecondaryFlag[])Enum.GetValues(typeof(SecondaryFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (SecondaryFlag flag in (SecondaryFlag[])Enum.GetValues(typeof(SecondaryFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(SecondaryFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Secondary stats should contain {Enum.GetValues(typeof(SecondaryFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (SecondaryFlag flag in (SecondaryFlag[])Enum.GetValues(typeof(SecondaryFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    public enum SecondaryFlag
    {
        CritChance,
        CritBonus,
        AttackSpeed,
        MoveSpeed,
        Stamina,
        Endurance,
        Accuracy,
        Reflex,
        Vitality,
        Fortitude,
        Knowledge,
        Perception,
        Faith,
        Will,
        Spirit,
        Luck
    }
}
