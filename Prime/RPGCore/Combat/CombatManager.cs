using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Core.Items;
using RPG.Core.Items.Defense;
using RPG.Core.Items.Offense;
using RPG.Core.Units;
using RPG.Core.Tools;

namespace RPG.Core.Combat
{
    public class Combat
    {
        public static int AttackUnit(Unit attacker, Unit defender, Weapon attackingWeapons)
        {

            if (attacker.Attack(defender, attackingWeapons))
            {
                return defender.TakeDamage(attacker.DealDamage(attackingWeapons));
            }

            return 0;
        }
    }

    //New
    class Combat2
    {
        int attkBonus;
        int ac;

        int body = 80;
        int head = 60;
        int legs = 80;
        int feet = 40;
        int arms = 80;
        int hands = 60;

        readonly Dictionary<ArmorSlots, double> BodyPartAC = new Dictionary<ArmorSlots, double>()
        {
            { ArmorSlots.Body, 0.45 },
            { ArmorSlots.Head, 0.10 },
            { ArmorSlots.Legs, 0.15 },
            { ArmorSlots.Feet, 0.10 },
            { ArmorSlots.Arms, 0.15 },
            { ArmorSlots.Hands, 0.05 }

        };

        //public enum ArmorBodyPart
        //{
        //    Body,
        //    Head,
        //    Legs,
        //    Feet,
        //    Arms,
        //    Hands
        //}

        //public enum BodyPart
        //{
        //    Body = 45,
        //    Head = 10,
        //    Legs = 15,
        //    Feet = 10,
        //    Arms = 15,
        //    Hands = 5
        //}


        public void AttackDefense()
        {
            int roll = Roll.D100();
            int dmg = 20;

            attkBonus = 5;
            ac = GetAC();



            roll += attkBonus;

            roll = 52;

            if (roll >= ac)
            {

            }
            else
            {
                double absorbPercent = ((double)ac - (double)roll) / (double)ac;
                double absorbAmount = dmg * absorbPercent;

                dmg -= (int)absorbAmount;

            }

            Armor a = new Armor();
            a.ArmorType = ArmorTypes.Plate;
            a.Hardness = 2;

            int r;

            r = a.GetResistAmount(DamageTypes.Slashing);
            r = a.GetResistAmount(DamageTypes.Blunt);
            r = a.GetResistAmount(DamageTypes.Piercing);

            a.ArmorType = ArmorTypes.Chain;

            //r = a.GetResistAmount(Items.DamageTypes.Slashing);
            //r = a.GetResistAmount(Items.DamageTypes.Blunt);
            //r = a.GetResistAmount(Items.DamageTypes.Piercing);

            //get Damge resistance percent
            double dmgr = (double)r / 100;

            //calculate dmg resistance amount and subtract from damage
            double total = dmg - (dmg * dmgr);

            //just to check values :: remove at will
            int xf = r;




        }

        //Weighted AC
        public int GetAC()
        {
            double total = 0;


            total += body * BodyPartAC[ArmorSlots.Body];
            total += head * BodyPartAC[ArmorSlots.Head];
            total += legs * BodyPartAC[ArmorSlots.Legs];
            total += feet * BodyPartAC[ArmorSlots.Feet];
            total += arms * BodyPartAC[ArmorSlots.Arms];
            total += hands * BodyPartAC[ArmorSlots.Hands];

            return (int)total;

        }




    }

    public class Damage
    {
        /// <summary>
        /// DamageType by 'string' or 'enum'
        /// </summary>
        public DamageTypes DamageType { get; set; } = DamageTypes.None;
        public string DamageTypeName { get; set; } = string.Empty;
        /// <summary>
        /// Actual damage value
        /// </summary>
        public int DamageValue { get; set; }

        /// <summary>
        /// Amount of resistance applied to the damage by the SelectedDefender
        /// </summary>
        public int AmountResisted { get; set; }

        public int DamageAfterResistance
        {
            get
            {
                int damageAfterResistance = DamageValue - AmountResisted;

                if (damageAfterResistance < 0)
                    damageAfterResistance = 0;

                return damageAfterResistance;
            }
        }

        public Damage() { }
        /// <summary>
        /// Basic damage value with no type
        /// </summary>
        /// <param name="damageValue"></param>
        public Damage(int damageValue)
        {
            DamageValue = damageValue;
            DamageType = DamageTypes.None;
        }
        /// <summary>
        /// DamageType as 'string'
        /// </summary>
        /// <param name="damageValue"></param>
        /// <param name="damageType"></param>
        public Damage(int damageValue, string damageType)
        {
            DamageValue = damageValue;
            DamageTypeName = damageType;
            DamageType = DamageTypes.None;
        }
        /// <summary>
        /// DamageType as 'enum'
        /// </summary>
        /// <param name="damageValue"></param>
        /// <param name="damageType"></param>
        public Damage(int damageValue, DamageTypes damageType)
        {
            DamageValue = damageValue;
            DamageType = damageType;
        }
    }

    public class DamageBlob
    {
        public List<Damage> DamageList { get; set; }
        //public Unit Attacker { get; set; }
        //public Unit Defender { get; set; }

        public DamageBlob() { }

        ///// <summary>
        ///// Attacking and defending units with no damage set
        ///// </summary>
        ///// <param name="attacker"></param>
        ///// <param name="SelectedDefender"></param>
        //public DamageBlob(Unit attacker, Unit SelectedDefender)
        //{
        //    Attacker = attacker;
        //    Defender = Defender;
        //}

        ///// <summary>
        ///// Full list of damages with attacking and defending units
        ///// </summary>
        ///// <param name="attacker"></param>
        ///// <param name="SelectedDefender"></param>
        ///// <param name="damageList"></param>
        //public DamageBlob(Unit attacker, Unit SelectedDefender, List<Damage> damageList)
        //{
        //    DamageList = damageList;
        //    Attacker = attacker;
        //    Defender = Defender;
        //}

        ///// <summary>
        ///// Single damage with attacking and defending units
        ///// </summary>
        ///// <param name="attacker"></param>
        ///// <param name="SelectedDefender"></param>
        ///// <param name="damage"></param>
        //public DamageBlob(Unit attacker, Unit SelectedDefender, Damage damage)
        //{
        //    DamageList = new List<Damage>();
        //    DamageList.Add(damage);

        //    Attacker = attacker;
        //    Defender = Defender;
        //}

        /// <summary>
        /// Constructor with a full list of preset damages
        /// </summary>
        /// <param name="damageList"></param>
        public DamageBlob(List<Damage> damageList)
        {
            DamageList = damageList;
        }

        /// <summary>
        /// Constructor with a single preset damage
        /// </summary>
        /// <param name="damage"></param>
        public DamageBlob(Damage damage)
        {
            DamageList = new List<Damage>();
            DamageList.Add(damage);
        }

        /// <summary>
        /// Basic Constructor assigning a single, type-less damage value
        /// </summary>
        /// <param name="damageValue"></param>
        public DamageBlob(int damageValue)
        {
            Damage damage = new Damage(damageValue);
            DamageList = new List<Damage>();
            DamageList.Add(damage);
        }
    }

    public abstract class CombatBlob
    {
        public int HitChance { get; set; }
        public int DodgeChance { get; set; }
        public int BlockChance { get; set; }
        public int DeflectChange { get; set; }
    }

    public sealed class AttackBlob : CombatBlob
    {

        public AttackBlob() { }
        public AttackBlob(int attackValue)
        {
            HitChance = attackValue;

            DodgeChance = 0;
            BlockChance = 0;
            DeflectChange = 0;
        }

        public AttackBlob(int attackValue, int negateDodge, int negateBlock, int negateDeflect)
        {
            HitChance = attackValue;
            DodgeChance = negateDodge;
            BlockChance = negateBlock;
            DeflectChange = negateDeflect;
        }
    }

    public sealed class DefenseBlob : CombatBlob
    {
        public DefenseBlob() { }
        public DefenseBlob(int defenseValue)
        {
            HitChance = defenseValue;

            DodgeChance = 0;
            BlockChance = 0;
            DeflectChange = 0;
        }

        public DefenseBlob(int defenseValue, int dodge, int block, int deflect)
        {
            HitChance = defenseValue;
            DodgeChance = dodge;
            BlockChance = block;
            DeflectChange = deflect;
        }
    }

    #region DeadCode


    //class DamageBlob
    //{
    //public Unit Attacker { get; set; }
    //public Weapon WeaponUsed { get; set; }

    //public List<Property> DamageProperties { get; set; } = new List<Property>();
    //public List<Effects> EffectList { get; set; } = new List<Effects>();
    //public Dictionary<Weapon.WeaponEffects, int> WeaponEffectList { get; set; } = new Dictionary<Weapon.WeaponEffects, int>();

    //public DamageBlob() { }
    //public DamageBlob(AttackBlob attkBlob)
    //{
    //    Attacker = attkBlob.Attacker;
    //    WeaponUsed = attkBlob.WeaponAttackedWith;
    //}
    //}

    //    class SimpleUnitCombatManager
    //    {
    //        public SimpleUnit Attacker { get; set; } = new SimpleUnit();
    //        public SimpleUnit Defender { get; set; } = new SimpleUnit();



    //        public SimpleUnitCombatManager() { }

    //        public void UnitAttack(SimpleUnit attacker, SimpleUnit SelectedDefender)
    //        {
    //            Attacker = attacker;
    //            Defender = SelectedDefender;

    //            Random r = new Random();
    //            int attkRoll;

    //            attkRoll = r.Next(1, 20);
    //            attkRoll += Attacker.AttackBonus;

    //            if (attkRoll >= Defender.ArmorClass)
    //            {
    //                Defender.HitPoints -= r.Next(Attacker.MinDamage, Attacker.MaxDamage);

    //                if (Defender.HitPoints <= 0)
    //                    Defender.IsDead = true;

    //            }
    //        }


    //    }

    //    class Combat
    //    {
    //        private AttackBlob Attack;
    //        private DefenseBlob Defense;


    //        public Combat() { }

    //        public bool AttackerHit()
    //        {
    //            if (Attack.AttackRoll > Defense.TotalDefenseRoll)
    //                return true;
    //            else
    //                return false;
    //        }

    //        public void AttackOccured(AttackBlob attk, DefenseBlob def)
    //        {
    //            Attack = attk;
    //            Defense = def;

    //            if (AttackerHit())
    //            {
    //                Defense.Defender.AbsorbDamage(Attack.Attacker.DealDamage(Attack));
    //            }
    //        }
    //    }

    //    class AttackBlob
    //    {
    //        public Unit Attacker { get; set; }
    //        public Weapon.AttackTypes AttackType { get; set; }
    //        public Weapon WeaponAttackedWith { get; set; }

    //        public bool IsCriticalHit { get; set; } = false;
    //        public bool IsMassiveAttack { get; set; } = false;
    //        public int CriticalAmount { get; set; } = 0;

    //        public int LevelBonus { get; set; } = 0;
    //        public int BaseAttackBonus { get; set; } = 0;
    //        public int AttackTypeBonus { get; set; } = 0;
    //        public int WeaponTypeBonus { get; set; } = 0;
    //        public int DamageTypeBonus { get; set; } = 0;

    //        public int AttackRoll { get; set; }

    //        public int GetAllAttackBonuses
    //        {
    //            get
    //            {
    //                return BaseAttackBonus + AttackTypeBonus + WeaponTypeBonus;
    //            }
    //        }



    //        public int DodgeReduction { get; set; }
    //        public bool CanDodge { get; set; }
    //        public string[] EffectNames { get; set; }

    //        public List<Modify> ModifyList { get; set; } = new List<Modify>();

    //        public AttackBlob() { }
    //        public AttackBlob(Weapon w, int baseAttk, int dodgeReduct, bool canDodge, bool isMassiveAttk, string[] effectNames = null, List<Modify> modList = null)
    //        {
    //            WeaponAttackedWith = w;
    //            BaseAttackBonus = baseAttk;
    //            DodgeReduction = dodgeReduct;
    //            CanDodge = canDodge;
    //            IsMassiveAttack = isMassiveAttk;
    //            EffectNames = effectNames;
    //            ModifyList = modList;
    //        }
    //    }

    //    class DefenseBlob
    //    {
    //        public Unit Defender { get; set; }
    //        public int BaseDefense { get; set; }
    //        public int DodgeAmount { get; set; } = 0;
    //        public int DexBonus { get; set; }
    //        public int ArmorBonus { get; set; }
    //        public int LevelBonus { get; set; }
    //        public int TotalDefenseRoll { get; set; }

    //        public int MaxDefense
    //        {
    //            get
    //            {
    //                return BaseDefense + DodgeAmount + DexBonus + ArmorBonus + LevelBonus;
    //            }
    //        }

    //        public DefenseBlob() { }
    //        public DefenseBlob(Unit SelectedDefender) { this.Defender = SelectedDefender; }
    //        public DefenseBlob(Unit SelectedDefender, int dodgeAmount, int dexBonus, int armorBonus)
    //        {
    //            Defender = SelectedDefender;
    //            DodgeAmount = dodgeAmount;
    //            DexBonus = dexBonus;
    //            ArmorBonus = armorBonus;

    //        }

    //    }

    //    class DamageBlob
    //    {
    //        public Unit Attacker { get; set; }
    //        public Weapon WeaponUsed { get; set; }

    //        public List<Property> DamageProperties { get; set; } = new List<Property>();
    //        public List<Effects> EffectList { get; set; } = new List<Effects>();
    //        public Dictionary<Weapon.WeaponEffects, int> WeaponEffectList { get; set; } = new Dictionary<Weapon.WeaponEffects, int>();

    //        public DamageBlob() { }
    //        public DamageBlob(AttackBlob attkBlob)
    //        {
    //            Attacker = attkBlob.Attacker;
    //            WeaponUsed = attkBlob.WeaponAttackedWith;
    //        }


    //    }
    #endregion
}
