using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class MajorStats
    {
        public Dictionary<MajorFlag, Stat> Stats { get; }

        public MajorStats()
        {
            Stats = new Dictionary<MajorFlag, Stat>();

            Set();
        }

        public MajorStats(int[] values)
        {
            Stats = new Dictionary<MajorFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(MajorFlag)).Length - 1 != values.Length)
            {
                throw new IndexOutOfRangeException($"Major stats should contain {Enum.GetValues(typeof(MajorFlag)).Length - 1} itmes.");
            }

            int i = 0;

            foreach (MajorFlag flag in (MajorFlag[])Enum.GetValues(typeof(MajorFlag)))
            {
                if(flag != MajorFlag.Energy)
                {
                    Stats[flag].Set(values[i]);
                }

                i++;
            }
        }

        private void Set()
        {
            foreach (MajorFlag flag in (MajorFlag[])Enum.GetValues(typeof(MajorFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(MajorFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Major stats should contain {Enum.GetValues(typeof(MajorFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (MajorFlag flag in (MajorFlag[])Enum.GetValues(typeof(MajorFlag)))
            {
                Stats.Add(flag, new Stat(values[i], values[i]));

                i++;
            }
        }
    }

    [Flags]
    public enum MajorFlag
    {
        HP = 1,
        Power = 2,
        Magic = 4,
        Energy = 8
    }
}
