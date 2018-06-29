using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RPG.Standard.Combat;
using RPG.Standard.Items;
using RPG.Standard.Effects;
using RPG.Standard.Items.Offense;
using RPG.Standard.Tools;

namespace RPG.Standard.Units
{
    public partial class Unit
    {
        //Get all buffs for selected stat
        [DebuggerStepThrough]
        public int Effects(string name)
        {
            RefreshEffects();


            return (from effect in CurrentEffects
                    where effect.Name.ToUpper() == name.ToUpper()
                    select effect.Value).Sum();




            //var effects =
            //    from effect in CurrentEffects
            //    where effect.Name.ToUpper() == name.ToUpper()
            //    select effect;

            //int value = 0;

            //foreach (var i in effects)
            //{
            //    value += i.Value;
            //}

            //return value;
        }

        public float GetWeightCarried()
        {


            //foreach (Item i in Items)
            //{
            //    wt += i.Weight;
            //}

            //foreach (KeyValuePair<EquipmentSlot, Item> item in EquipedItems)
            //{
            //    wt += item.Value.Weight;
            //}

            float wt = (from e in Items select e.Weight).Sum() +
                       (from e in EquipedWeapons select e.Value.Weight).Sum() +
                       (from e in EquipedArmor select e.Value.Weight).Sum() +
                       (from e in MiscEquipment select e.Value.Weight).Sum() +
                       (from e in EquipedArtifacts select e.Value.Weight).Sum();

            if (wt > MaxCarryCapacity)
                OverLoadedWithWeight = true;
            else
                OverLoadedWithWeight = false;

            return wt;
        }

        private void RefreshItems()
        {
            WeightCarried = GetWeightCarried();
        }

        //Set a buff and return its unique name
        public string AddEffect(string name, int value, string desc, string source, int ttl)
        {
            CurrentEffects.Add(new Effect(name, value, desc, source, ttl));
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        //Set a buff and return its unique name
        public string AddEffect(Effect effect)
        {
            CurrentEffects.Add(effect);
            return CurrentEffects[CurrentEffects.Count - 1].Name;
        }

        public void RefreshEffects()
        {
            if (CurrentEffects == null)
                CurrentEffects = new List<Effect>();

            foreach (Effect e in CurrentEffects)
                e.Refresh();

            CurrentEffects.RemoveAll(CurrentEffects => CurrentEffects.IsActive == false);
        }

        //Get all buffs for selected stat
        public int GetResistaneValue(Damage damage)
        {
            if (DamagResistances == null)
                DamagResistances = new List<DamageResistance>();

            var resistances =
                from resistance in DamagResistances
                where resistance.DamageType == damage.DamageType || resistance.DamageTypeName == damage.DamageTypeName
                select resistance;

            int value = 0;

            foreach (var i in resistances)
            {
                value += i.Value;
            }

            return value + Effects(damage.DamageTypeName) + Effects(damage.DamageType.ToString());
        }

        //Get all buffs for selected stat
        public int GetResistaneValue(DamageTypes damageType)
        {
            if (DamagResistances == null)
                DamagResistances = new List<DamageResistance>();

            var resistances =
                from resistance in DamagResistances
                where resistance.DamageType == damageType
                select resistance;

            int value = 0;

            foreach (var i in resistances)
            {
                value += i.Value;
            }

            return value + Effects(damageType.ToString());
        }

        //Get all buffs for selected stat
        public int GetResistaneValue(string damageTypeName)
        {

            if (DamagResistances == null)
                DamagResistances = new List<DamageResistance>();

            var resistances =
                from resistance in DamagResistances
                where resistance.DamageTypeName == damageTypeName
                select resistance;

            int value = 0;

            foreach (var i in resistances)
            {
                value += i.Value;
            }

            return value + Effects(damageTypeName);
        }

        public DamageBlob DealDamage(Weapon weapon)
        {

            return new DamageBlob(weapon.DealDamage(StrengthBonus));
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

                d.AmountResisted = GetResistaneValue(d);
                totalDamage += d.DamageAfterResistance;
            }

            return totalDamage;
        }

        public int ApplyDamage(DamageBlob damageBlob)
        {
            int damageTaken = 0;

            foreach (Damage d in damageBlob.DamageList)
            {
                HitPoints -= d.DamageAfterResistance;
                damageTaken += d.DamageAfterResistance;
            }

            return damageTaken;
        }

        public int ApplyDamage(int damageValue)
        {
            HitPoints -= damageValue;
            return damageValue;
        }

        public int GetBaseStatBonus(BaseStat stat)
        {
            switch (stat)
            {
                case BaseStat.Strength:
                    return StrengthBonus;
                case BaseStat.Dexterity:
                    return DexterityBonus;
                case BaseStat.Constitution:
                    return ConstitutionBonus;
                case BaseStat.Intelligence:
                    return IntelligenceBonus;
                case BaseStat.Wisdom:
                    return WisdomBonus;
                case BaseStat.Charisma:
                    return CharismaBonus;
                default:
                    return 0;
            }

        }

        public int GetBaseStat(BaseStat stat)
        {
            switch (stat)
            {
                case BaseStat.Strength:
                    return Strength;
                case BaseStat.Dexterity:
                    return Dexterity;
                case BaseStat.Constitution:
                    return Constitution;
                case BaseStat.Intelligence:
                    return Intelligence;
                case BaseStat.Wisdom:
                    return Wisdom;
                case BaseStat.Charisma:
                    return Charisma;
                default:
                    return 0;
            }
        }
    }
}
