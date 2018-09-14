using RPG.Standard.Base;
using RPG.Standard.Combat;
using RPG.Standard.Items;
using RPG.Standard.Items.Offense;
using RPG.Standard.Worlds;
using System;

namespace RPG.Standard.Units
{
    public partial class Unit : Object,  ISectionItem
    {
        public Guid SectionId { get; set; }
        public string UnitName { get; set; }

        public float WeightCarried => Equipment.WeightCarried;
        public bool IsDead => Stats.HitPoints.Value <= 0;
        public bool OverLoadedWithWeight => WeightCarried > Stats.MaxCarryCapacity.Value;

        public EquipmentManager Equipment { get; }
        public UnitStats Stats { get; }

        public Unit() : base()
        {
            Stats = new UnitStats
            (
                new int[] { 12, 14, 14, 11, 10, 11 },
                new int[] { 12, 14, 14, 11, 10, 11, 12, 14, 14, 11, 10, 11, 20, 24, 12, 14 },
                new int[] { 34, 23, 50, 25, 0, 0, 0 },
                new int[] { 14, 14, 11, 10, 11, 12, 14, 14, 11, 10, 11, 20, 24 },
                new int[] { 34, 23, 50, 25, 12, 47, 14 },
                new int[] { 34, 23, 50}
            );

            Equipment = new EquipmentManager
            (
                Stats.Energy, 
                Stats.BluntResist, 
                Stats.PierceResist, 
                Stats.SlashResist, 
                Stats.ArmorClass,
                Stats.ParryChance,
                Stats.BlockBonus
            );

            EnergyRefresh();
        }

        public Unit(int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType, int[] weaponType)
        {
            Stats = new UnitStats(primary, secondary, defense, element, armorType, weaponType);

            Equipment = new EquipmentManager
            (
                Stats.Energy,
                Stats.BluntResist,
                Stats.PierceResist,
                Stats.SlashResist,
                Stats.ArmorClass,
                Stats.ParryChance,
                Stats.BlockBonus
            );

            EnergyRefresh();
        }

        public void EnergyRefresh()
        {
            Stats.Energy = new Stat(Stats.Energy.Value, Equipment.Energy.Value);
        }

        public int ApplyWeaponDamage(int damageValue)
        {
            Stats.HitPoints.Adjust(-damageValue);
            return damageValue;
        }

        public void PerformMeleeAttack(Unit defender, Weapon weapon)
        {
            var attack = new MeleeWeaponAttack(this, defender, weapon);

            defender.DefendeAgainstMeleeWeaponAttack(attack);
        }

        public void DefendeAgainstMeleeWeaponAttack(MeleeWeaponAttack attack)
        {
            var defense = new MeleeWeaponDefense(attack);

            defense.DefendAgainstAttack();
        }
    }
}
