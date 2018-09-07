using RPG.Standard.Base;
using RPG.Standard.Base.Stats;
using RPG.Standard.Combat;
using RPG.Standard.Effects;
using RPG.Standard.Items;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using RPG.Standard.Tools;
using RPG.Standard.Worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RPG.Standard.Units
{
    public partial class Unit : UnitStats, ISectionItem
    {
        public Guid SectionId { get; set; }
        public string UnitName { get; set; }

        public int CriticalMultiplier { get; set; }

        public float WeightCarried { get; private set; }

        public bool IsDead => HitPoints.Value == 0;
        public bool OverLoadedWithWeight { get; private set; } = false;
        public bool Attack(Unit defender) => Roll.AttackRoll(AttackBonus()) >= defender.ArmorClass.Value;
        public bool Attack(Unit defender, Weapon weapon) => Roll.AttackRoll(AttackBonus(weapon)) >= defender.ArmorClass.Value;

        public EquipmentManager Equipment = new EquipmentManager();

        public Unit() : base() { }

        public Unit(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType)
            : base(major, primary, secondary, defense, element, armorType)
        {

        }

        private int ClassAttackBonsus { get; set; }

        protected List<Property> UnitProperties { get; set; } = new List<Property>();
        protected List<DamageResistance> DamagResistances { get; set; } = new List<DamageResistance>();



        public static bool Search() => throw new NotImplementedException();
        public static bool CastSpell() => throw new NotImplementedException();
        public static bool UseSpecialPower() => throw new NotImplementedException();
        public static bool Move() => throw new NotImplementedException();
        public static bool UseItem() => throw new NotImplementedException();

        public string AddEffect(string name, int value, string desc, string source, int ttl)
        {
            CurrentEffects.Add(new Effect(name, value, desc, source, ttl));
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        public string AddEffect(Effect effect)
        {
            CurrentEffects.Add(effect);
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        public int GetResistanceValue(Damage damage)
        {
            int resistance = DamagResistances.Where(x => x.DamageType == damage.DamageType || x.DamageTypeName == damage.DamageTypeName).Sum(x => x.Value);
            return resistance + Effects(damage.DamageTypeName) + Effects(damage.DamageType.ToString());
        }

        public int GetResistanceValue(DamageType damageType)
        {
            int resistance = DamagResistances.Where(x => x.DamageType == damageType).Sum(x => x.Value);
            return resistance + Effects(damageType.ToString());
        }

        public int GetResistanceValue(string damageTypeName)
        {
            int resistance = DamagResistances.Where(x => x.DamageTypeName == damageTypeName).Sum(x => x.Value);
            return resistance + Effects(damageTypeName);
        }

        public DamageBlob DealDamage(Weapon weapon)
        {
            return new DamageBlob(weapon.DealDamage(Strength.Bonus));
        }

        public int TakeDamage(DamageBlob damageBlob)
        {
            int damageTaken;
            ApplyResistanceToDamage(damageBlob);
            damageTaken = ApplyDamage(damageBlob);

            return damageTaken;
        }

        public int ApplyResistanceToDamage(DamageBlob damageBlob)
        {
            int totalDamage = 0;

            foreach (Damage d in damageBlob.DamageList)
            {
                d.AmountResisted = GetResistanceValue(d);
                totalDamage += d.DamageAfterResistance;
            }

            return totalDamage;
        }

        public int ApplyDamage(DamageBlob damageBlob)
        {
            int damageTaken = 0;

            foreach (Damage d in damageBlob.DamageList)
            {
                HitPoints.Adjust(-d.DamageAfterResistance);
                damageTaken += d.DamageAfterResistance;
            }

            return damageTaken;
        }

        public int ApplyDamage(int damageValue)
        {
            HitPoints.Adjust(-damageValue);
            return damageValue;
        }

        public int GetBaseStatBonus(Primary stat)
        {
            switch (stat)
            {
                case Primary.Str:
                    return Strength.Bonus;
                case Primary.Dex:
                    return Dexterity.Bonus;
                case Primary.Con:
                    return Constitution.Bonus;
                case Primary.Int:
                    return Intelligence.Bonus;
                case Primary.Wis:
                    return Wisdom.Bonus;
                case Primary.Cha:
                    return Charisma.Bonus;
                default:
                    return 0;
            }
        }

        public int AttackBonus()
        {
            return AttackBonus(Equipment.EquipedWeapon);
        }

        public int AttackBonus(Weapon weapon)
        {
            return UnitLevel.Bonus + ClassAttackBonsus + weapon.AttackBonus + GetBaseStatBonus(weapon.PrimaryWeaponStat) + Effects("AttackBonus");
        }
    }
}
