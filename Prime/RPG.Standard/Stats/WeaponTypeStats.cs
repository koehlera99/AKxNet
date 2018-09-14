using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class WeaponTypeStats
    {
        public Dictionary<WeaponTypeFlag, Stat> Stats { get; }

        public WeaponTypeStats()
        {
            Stats = new Dictionary<WeaponTypeFlag, Stat>();

            Set();
        }

        public WeaponTypeStats(int[] values)
        {
            Stats = new Dictionary<WeaponTypeFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(WeaponTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Weapon type stats should contain {Enum.GetValues(typeof(WeaponTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (WeaponTypeFlag flag in (WeaponTypeFlag[])Enum.GetValues(typeof(WeaponTypeFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (WeaponTypeFlag flag in (WeaponTypeFlag[])Enum.GetValues(typeof(WeaponTypeFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(WeaponTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Weapon type stats should contain {Enum.GetValues(typeof(WeaponTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (WeaponTypeFlag flag in (WeaponTypeFlag[])Enum.GetValues(typeof(WeaponTypeFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    public enum WeaponTypeFlag
    {
        SlashingWeapons,
        BluntWeapons,
        PiercingWeapons
    }
}
