﻿using RPG.Standard.Items;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using RPG.Standard.Tools;
using System;

namespace RPG.Standard.Units
{
    public partial class Unit
    {
        #region Dead Code
        //[Obsolete]
        //public void EquipItem(Item i, EquipmentSlot equipmentType)
        //{
        //    if (EquipedItems.ContainsKey(equipmentType))
        //        UnEquipItem(equipmentType);
        //    else if (equipmentType == EquipmentSlot.BothHands)
        //    {
        //        if (EquipedItems.ContainsKey(EquipmentSlot.PrimaryHand))
        //            UnEquipItem(EquipmentSlot.PrimaryHand);
        //        if (EquipedItems.ContainsKey(EquipmentSlot.OffHand))
        //            UnEquipItem(EquipmentSlot.OffHand);
        //    }
        //    else if (equipmentType == EquipmentSlot.PrimaryHand || equipmentType == EquipmentSlot.OffHand)
        //    {
        //        if (EquipedItems.ContainsKey(EquipmentSlot.BothHands))
        //            UnEquipItem(EquipmentSlot.BothHands);
        //    }

        //    i.IsEquiped = true;
        //    EquipedItems.Add(equipmentType, i);
        //}

        //[Obsolete]
        //public void UnEquipItem(Item i)
        //{
        //    i.IsEquiped = false;

        //    if (EquipedItems.ContainsKey(i.EquipLocation))
        //    {
        //        Items.Add(i);
        //        EquipedItems.Remove(i.EquipLocation);
        //    }
        //}

        //[Obsolete]
        //public void UnEquipItem(EquipmentSlot equipmentType)
        //{
        //    if (EquipedItems.ContainsKey(equipmentType))
        //    {
        //        EquipedItems[equipmentType].IsEquiped = false;
        //        Items.Add(EquipedItems[equipmentType]);
        //        EquipedItems.Remove(equipmentType);
        //    }
        //}





        ////Melee Defense
        //public int MeleeDefense
        //{
        //    get
        //    {
        //        Random r = new Random();

        //        if (r.Next(1, 100) < DodgeChance)
        //            return ArmorClass + Effects("MeleeDefense") + DodgeBonus;
        //        else
        //            return ArmorClass + Effects("MeleeDefense");
        //    }
        //}

        ////Ranged Defense
        //public int RangedDefense
        //{
        //    get
        //    {
        //        Random r = new Random();

        //        if (r.Next(1, 100) < DodgeChance)
        //            return ArmorClass + Effects("RangedDefense") + DodgeBonus;
        //        else
        //            return ArmorClass + Effects("RangedDefense");
        //    }
        //}

        //int ac = 0;

        //foreach (var pair in EquipedItems)
        //{
        //    Item i = EquipedItems[pair.Key];

        //    if (i.ItemType == ItemTypes.EquipedArmor)
        //    {
        //        EquipedArmor a = (EquipedArmor)i;
        //        ac += a.ArmorClass;
        //    }
        //}

        //foreach (var pair in EquipedWeapons)
        //{
        //    Item i = EquipedWeapons[pair.Key];

        //    if (i.ItemType == ItemTypes.EquipedArmor)
        //    {
        //        EquipedArmor a = (EquipedArmor)i;
        //        ac += a.ArmorClass;
        //    }

        //    if (i.ItemType == ItemTypes.Weapon)
        //    {
        //        Weapon w = (Weapon)i;
        //        ac += w.DefenseBonus;
        //    }
        //}

        //struct SecondaryStats
        //{
        //    public int Vitality { get; set; }
        //    public int Endurance { get; set; }
        //    public int Luck { get; set; }
        //    public int Agility { get; set; }
        //    public int Accuracy { get; set; }
        //}

        //struct Proficiences
        //{
        //    /// <summary>
        //    /// Damage ArmorType Proficiencies
        //    /// </summary>
        //    public int SlashingWeapons { get; set; }
        //    public int BluntWeapons { get; set; }
        //    public int PiercingWeapons { get; set; }

        //    /// <summary>
        //    /// Weapon ArmorType Proficiences
        //    /// </summary>
        //    public int Throwing { get; set; }
        //    public int Martial { get; set; }
        //    public int TwoHanded { get; set; }
        //    public int LightRanged { get; set; }
        //    public int TwoHandedRanged { get; set; }

        //    /// <summary>
        //    /// EquipedArmor ArmorType Proficiencies
        //    /// </summary>
        //    public int ClothArmor { get; set; }
        //    public int ChainMail { get; set; }
        //    public int RingMail { get; set; }
        //    public int ScaleMail { get; set; }
        //    public int PlateMail { get; set; }
        //    public int Shields { get; set; }
        //}

        #endregion


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


}
