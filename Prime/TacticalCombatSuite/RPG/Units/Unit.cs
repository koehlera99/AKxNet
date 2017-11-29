using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.RPG.Worlds;
using TCS.RPG.Effects;
using TCS.RPG.Items;

namespace TCS.RPG.Units
{
    /// <summary>
    /// Properties of a typical Unit
    /// </summary>
    public partial class Unit : Object, ISectionItem

    {
        #region Stats
        //Primary Stats
        private int _strength = 10;
        private int _dexterity = 10;
        private int _constitution = 10;
        private int _intelligence = 10;
        private int _wisdom = 10;
        private int _charisma = 10;

        //Secondary Stats
        private int _stamina;
        private int _accuracy;
        private int _reflex;
        private int _vitality;
        private int _endurance;
        private int _attunement;
        private int _faith;
        private int _will;
        private int _luck;
        #endregion

        #region Proficiencis
        //Damage Proficiencies
        private int _slashingWeapons;
        private int _bluntWeapons;
        private int _PiercingWeapons;

        //Weapon ArmorType Proficiences
        private int _throwing;
        private int _martial;
        private int _twoHanded;
        private int _lightRanged;
        private int _twoHandedRanged;

        //EquipedArmor ArmorType Proficiences
        private int _clothArmor;
        private int _chainMail;
        private int _ringMail;
        private int _scaleMail;
        private int _plateMail;
        private int _shields;
        #endregion

        private int _level = 0;
        private long _experience = 0;
        private int _hitpoints = 0;

        private int _power;
        private int _magic;
        private int _energy;

        private int _dodgeChance;
        private int _criticalChance;

        private int _speed;
        private const int bonusCalcAdj = 11;


        //Constructors
        public Unit() { }
    }

    [Flags]
    public enum BaseStat
    {
        None = 0,
        Strength = 1,
        Dexterity = 2,
        Constitution = 4,
        Intelligence = 8,
        Wisdom = 16,
        Charisma = 32
    }

    [Flags]
    public enum SecondaryStat
    {
        None = 0,
        Vitality = 1,
        Endurance = 2,
        Luck = 4,
        Agility = 8,
        Accuracy = 16,
        Attunement = 32
    }

    #region Dead Code
    //public int MovementSpeed
    //{
    //    get
    //    {
    //        if (OverLoadedWithWeight)
    //            return (DexBonus + Speed + GetEffect("Speed")) / 2;
    //        else
    //            return DexBonus + Speed + GetEffect("Speed");
    //    }
    //}

    /// <summary>
    /// Primary-Secondary Abilities
    /// </summary>
    //protected PrimaryStatistics Primary;
    //protected PrimaryStatistics Secondary;

    //protected List<Modify> ModifyList { get; set; } = new List<Modify>();


    //public short DamageTypeBonus(Weapon weapon)
    //{
    //    short dmgBonus = 0;

    //    //Damge ArmorType proficiencies
    //    if (weapon.DamageTypeName == Weapon.DamageTypes.Blunt)
    //        dmgBonus += BluntWeapons;
    //    else if (weapon.DamageTypeName == Weapon.DamageTypes.Piercing)
    //        dmgBonus += PiercingWeapons;
    //    else if (weapon.DamageTypeName == Weapon.DamageTypes.Slashing)
    //        dmgBonus += SlashingWeapons;

    //    return dmgBonus;
    //}

    //public short WeaponTypeBonus(Weapon weapon)
    //{
    //    short attkBonus = 0;

    //    //Weapon ArmorType Proficiencies
    //    if (weapon.WeaponType == Weapon.WeaponTypes.Throwing)
    //        attkBonus += Throwing;
    //    else if (weapon.WeaponType == Weapon.WeaponTypes.Martial)
    //        attkBonus += Martial;
    //    else if (weapon.WeaponType == Weapon.WeaponTypes.TwoHanded)
    //        attkBonus += TwoHanded;
    //    else if (weapon.WeaponType == Weapon.WeaponTypes.LightRanged)
    //        attkBonus += LightRanged;
    //    else if (weapon.WeaponType == Weapon.WeaponTypes.HeavyRanged)
    //        attkBonus += TwoHandedRanged;

    //    return attkBonus;
    //}

    //public short ArmorTypeBonus(EquipedArmor armor)
    //{
    //    short armorBonus = 0;

    //    //EquipedArmor ArmorType proficiencies
    //    if (armor.ArmorType == ArmorType.Cloth)
    //        armorBonus += ClothArmor;
    //    else if (armor.ArmorType == ArmorType.Chain)
    //        armorBonus += ChainMail;
    //    else if (armor.ArmorType == ArmorType.Ring)
    //        armorBonus += RingMail;
    //    else if (armor.ArmorType == ArmorType.Scale)
    //        armorBonus += ScaleMail;
    //    else if (armor.ArmorType == ArmorType.Plate)
    //        armorBonus += PlateMail;
    //    else if (armor.ArmorType == ArmorType.Shield)
    //        armorBonus += Shields;

    //    return armorBonus;
    //}








    //public AttackBlob WeaponAttack(Weapon weapon, Weapon.AttackTypes attkType)
    //{
    //    Random random = new Random();
    //    AttackBlob attkBlob = new AttackBlob();

    //    attkBlob.Attacker = this;
    //    attkBlob.WeaponAttackedWith = weapon;

    //    int criticalRoll;

    //    criticalRoll = random.Next(0, 100);

    //    if (criticalRoll <= CriticalChance)
    //    {
    //        attkBlob.IsCriticalHit = true;

    //        attkBlob.CriticalAmount = random.Next(LevelBonus, LevelBonus + CriticalDamage);

    //        if (criticalRoll <= 100 - weapon.AutoCritMax)
    //        {
    //            attkBlob.IsMassiveAttack = true;
    //            attkBlob.CriticalAmount *= 2;
    //        }
    //    }

    //    attkBlob.AttackType = attkType;

    //    switch (attkBlob.AttackType)
    //    {
    //        case Weapon.AttackTypes.Melee:
    //        case Weapon.AttackTypes.MeleeAOE:
    //            attkBlob.AttackTypeBonus = this.MeleeAttack;
    //            break;
    //        case Weapon.AttackTypes.Ranged:
    //        case Weapon.AttackTypes.RangedAOE:
    //            attkBlob.AttackTypeBonus = this.RangedAttack;
    //            break;
    //        case Weapon.AttackTypes.None:
    //        default:
    //            break;
    //    }

    //    attkBlob.LevelBonus = this.LevelBonus;
    //    attkBlob.BaseAttackBonus = this.BaseAttack;
    //    attkBlob.WeaponTypeBonus = this.WeaponTypeBonus(weapon);
    //    attkBlob.DamageTypeBonus = this.DamageTypeBonus(weapon);

    //    attkBlob.AttackRoll = random.Next(attkBlob.LevelBonus, attkBlob.GetAllAttackBonuses);

    //    return attkBlob;
    //}

    //public DamageBlob DealDamage(AttackBlob attk)
    //{
    //    DamageBlob dmgBlob = new DamageBlob(attk);

    //    //int randomRoll = 0;
    //    //DamageBlob dmg = new DamageBlob();
    //    //dmg.BaseDamage = 1;
    //    //Random random = new Random();

    //    //if (weapon.AutoCritMax == 0)
    //    //{
    //    //    dmg.BaseDamage += CriticalDamage;
    //    //    dmg.BaseDamage += weapon.MaxDamage;
    //    //}
    //    //else
    //    //{
    //    //    randomRoll = random.Next(1, 100);

    //    //    if (randomRoll <= this.CriticalChance)
    //    //        dmg.BaseDamage += CriticalDamage;

    //    //    randomRoll = random.Next(weapon.MinDamage, weapon.MaxDamage);
    //    //    dmg.BaseDamage = randomRoll;
    //    //}

    //    //if (weapon.IsMeleeAttack)
    //    //    dmg.BaseDamage += Strength;
    //    //else
    //    //    dmg.BaseDamage += Dexterity;

    //    //dmg.DamageTypeName = weapon.DamageTypeName;
    //    ////dmg. = weapon.AttackType;
    //    //dmg.WeaponEffect = weapon.WeaponEffect;

    //    return dmgBlob;
    //}

    //public DefenseBlob DefenseRoll()
    //{
    //    DefenseBlob defBlob = new DefenseBlob(this);
    //    Random random = new Random();

    //    int randomRoll;

    //    randomRoll = random.Next(1, 100);

    //    if (randomRoll <= this.DodgeChance)
    //        defBlob.DodgeAmount = this.DodgeBonus;

    //    defBlob.BaseDefense = this.LevelBonus;
    //    defBlob.ArmorBonus = this.ArmorClass;
    //    defBlob.DexBonus = this.DexBonus;

    //    defBlob.TotalDefenseRoll = random.Next(LevelBonus, defBlob.MaxDefense);

    //    return defBlob;
    //}

    //public void AbsorbDamage(DamageBlob damage)
    //{
    //    int damageTaken = 0;

    //    //damageTaken += damage;
    //    this.HP -= damageTaken;

    //    if (this.HitPoints <= 0)
    //        this.IsDead = true;
    //    else
    //        this.IsDead = false;

    //    //PrintText.NormalPrint("HP Remaining: " + this.HitPoints);
    //}

    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

















    //    

    //    struct Alignments
    //    {
    //        int Good;
    //        int Evil;
    //        int Law;
    //        int Chaos;
    //        int Neutral;
    //    }

    //    struct Elements
    //    {
    //        int Fire;
    //        int Earth;
    //        int Air;
    //        int Water;

    //        int Electric;
    //        int Sound;
    //        int Force;
    //        int Magnetic;

    //        int Holy;
    //        int Shadow;
    //        int Light;
    //        int Darkness;

    //        int Poison;
    //        int Heal;
    //        int Life;
    //        int Death;

    //        int Moon;
    //        int Star;
    //        int Gravity;
    //        int Void;

    //        int Acid;
    //        int Mind;
    //        int Ghost;
    //        int Plague;
    //    }

    //    struct AbilityScores
    //    {
    //        short Strength;
    //        short Dexterity;
    //        short Constitution;
    //        short Intelligence;
    //        short Wisdom;
    //        short Charisma;
    //    }

    //    // Damage ArmorType Proficiencies


    //    // Weapon ArmorType Proficiencies


    //    struct WeaponTypes
    //    {
    //        short Throwing;
    //        short Martial;
    //        short TwoHanded;
    //        short LightRanged;
    //        short TwoHandedRanged;
    //    }

    //    struct ThrowingWeapons
    //    {
    //        short Dagger;           //Slashing
    //        short ThrowingHammer;   //Blunt
    //        short Javalin;          //Piercing
    //    }

    //    struct MartialWeapons
    //    {
    //        short Longsword;        //Slashing
    //        short WarHammer;        //Blunt
    //        short Spear;            //Piercing
    //    }

    //    struct TwoHandedWeapons
    //    {
    //        short FullBlade;        //Slashing
    //        short MorningStar;      //Blunt
    //        short Lance;            //Piercing
    //    }

    //    struct WeaponDamageTypes
    //    {
    //        short Slashing;
    //        short Blunt;
    //        short Piercing;
    //    }

    //    struct ArmorTypes
    //    {
    //        short ClothArmor;
    //        short ChainMail;
    //        short RingMail;
    //        short ScaleMail;
    //        short PlateMail;
    //        short Shields;
    //    }

    //    class Element
    //    {
    //        public int ElementID { get; set; }
    //        public string ElementName { get; set; }
    //        public int ElementValue { get; set; }
    //        public string ElementDescription { get; set; }
    //        public string ElementHardness { get; set; }
    //    }

    //    enum ElementState
    //    {
    //        None, Solid, Liquid, Gas,
    //        Ion, Paricle, Wave, Beam,
    //        Ethereal, Plasma, Phase
    //    }

    //    enum PowerSource
    //    {
    //        None,
    //        Physical,   //Strength, Dexterity, Constitution
    //        Magic,      //Intelligence
    //        Divine,     //Charisma
    //        Nature,     //Wisdom
    //        Psyonic,    //Intelligence, Charisma
    //        Tech,       //Intelligence, Wisdom
    //        Mind      //Charisma, Wisdom
    //    }

    //    class ArmoredKnight : Unit
    //    {

    //    }

    //    class Berserker : Unit
    //    {
    //        public bool IsBerserking { get; set; }
    //        public int BerserkBonus { get; set; }
    //        public int BerserkDebuff { get; set; }
    //    }





    //    class Race
    //    {
    //        string RaceName;
    //    }

    //    interface IRace
    //    {

    //    }

    //    enum PrimaryStatistics
    //    {
    //        Strength,
    //        Dexterity,
    //        Constitution,
    //        Intelligence,
    //        Wisdom,
    //        Charisma
    //    }

    //    enum SecondaryStats
    //    {
    //        CriticalAmount,
    //        CriticalChance,
    //        DodgeChance
    //    }


    //    static class Action
    //    {
    //        enum Attack
    //        {
    //            Basic,
    //            Melee,
    //            Ranged,
    //            Throw
    //        }

    //        enum Spell
    //        {
    //            None,
    //            Cast,
    //            Interupt,
    //            Dispell,
    //            Negate
    //        }

    //        enum Maneuver
    //        {
    //            None,
    //            Basic,
    //            Sunder,
    //            Trip,
    //            Disarm,
    //            Stun,
    //            Mark,
    //            Push,
    //            Pull,
    //            Slide,
    //            Intimidate,
    //            Inspire,
    //            Run,
    //            Hide,
    //            Jump,
    //            DropProne,
    //            Escape,
    //            FindCover,
    //            Deflect,
    //            Gaurd
    //        }

    //        enum ActionType
    //        {
    //            None,
    //            Attack,
    //            Defend,
    //            CastSpell,
    //            WeaponManuever,
    //            Run,
    //            Escape,
    //            Stealth
    //        }
    //    }

    //    //class Berserker : Unit, IBerserker
    //    //{
    //    //    private bool isBerserking;
    //    //    private int berserkBonus;
    //    //    private int berserkDebuff;

    //    //    public bool IsBerserking
    //    //    {
    //    //        get { return isBerserking; }
    //    //        set { isBerserking = value; }
    //    //    }

    //    //    public int BerserkBonus
    //    //    {
    //    //        get { return berserkBonus; }
    //    //        set { berserkBonus = value; }
    //    //    }

    //    //    public int BerserkDebuff
    //    //    {
    //    //        get { return berserkDebuff; }
    //    //        set { berserkDebuff = value; }
    //    //    }

    //    //    public void Berserk()
    //    //    {
    //    //        MaxHP += BerserkBonus * Lvl;
    //    //        HP += BerserkBonus * Lvl;
    //    //        //MaxPower += BerserkBonus * 10 * Lvl;
    //    //        MeleeAttackBonus += BerserkBonus;
    //    //        RangedAttackBonus -= BerserkDebuff;
    //    //        DodgeChance = 0;
    //    //    }

    //    //    public void UnBerserk()
    //    //    {
    //    //        MaxHP -= BerserkBonus * Lvl;

    //    //        if (HP > MaxHP)
    //    //            HP = MaxHP;
    //    //    }


    //    //    //Berserking Abilities
    //    //    int BHPIncrease;
    //    //    int BDmgIncrease;

    //    //    int BBluntVulnerable;
    //    //    int BPierceVulnerable;
    //    //    int BSlashVulnerable;

    //    //    int BPowerConsumption;


    //    //}

    //    //static class Combat
    //    //{
    //    //    public static int AttackAction(Character attacker, Character SelectedDefender)
    //    //    {
    //    //        if (attacker.AttackRoll() >= SelectedDefender.DefenseRoll())
    //    //        {
    //    //            int damage = attacker.DealDamage();
    //    //            SelectedDefender.AbsorbDamage(damage);
    //    //            return damage;
    //    //        }
    //    //        else
    //    //        {
    //    //            return 0;
    //    //        }
    //    //    }

    //    //    public static bool CombatRound(int attackRoll, int defenceRoll)
    //    //    {

    //    //        return false;
    //    //    }
    //    //}

    #endregion

}
