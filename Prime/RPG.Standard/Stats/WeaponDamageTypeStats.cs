using RPG.Standard.Base;
using System;
using System.Collections.Generic;

namespace RPG.Standard.Stats
{
    public class WeaponDamageTypeStats
    {
        public Dictionary<WeaponDamageTypeFlag, Stat> Stats { get; }

        public WeaponDamageTypeStats()
        {
            Stats = new Dictionary<WeaponDamageTypeFlag, Stat>();

            Set();
        }

        public WeaponDamageTypeStats(int[] values)
        {
            Stats = new Dictionary<WeaponDamageTypeFlag, Stat>();

            Set(values);
        }

        public void SetAll(int[] values)
        {
            if (Enum.GetValues(typeof(WeaponDamageTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Weapon type stats should contain {Enum.GetValues(typeof(WeaponDamageTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (WeaponDamageTypeFlag flag in (WeaponDamageTypeFlag[])Enum.GetValues(typeof(WeaponDamageTypeFlag)))
            {
                Stats[flag].Set(values[i++]);
            }
        }

        private void Set()
        {
            foreach (WeaponDamageTypeFlag flag in (WeaponDamageTypeFlag[])Enum.GetValues(typeof(WeaponDamageTypeFlag)))
            {
                Stats.Add(flag, new Stat());
            }
        }

        private void Set(int[] values)
        {
            if (Enum.GetValues(typeof(WeaponDamageTypeFlag)).Length != values.Length)
            {
                throw new IndexOutOfRangeException($"Weapon type stats should contain {Enum.GetValues(typeof(WeaponDamageTypeFlag)).Length} itmes.");
            }

            int i = 0;

            foreach (WeaponDamageTypeFlag flag in (WeaponDamageTypeFlag[])Enum.GetValues(typeof(WeaponDamageTypeFlag)))
            {
                Stats.Add(flag, new Stat(values[i++]));
            }
        }
    }

    public enum WeaponDamageTypeFlag
    {
        SlashingWeapons,
        BluntWeapons,
        PiercingWeapons
    }
}
