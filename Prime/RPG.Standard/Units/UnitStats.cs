using RPG.Standard.Base;
using RPG.Standard.Stats;

namespace RPG.Standard.Units
{
    public class UnitStats : UnitStatBase
    {
        public Stat HitPoints { get; private set; }
        public Stat Power { get; private set; }
        public Stat Magic { get; private set; }
        public Stat Energy { get; set; }

        protected Stat Strength { get; private set; }
        protected Stat Dexterity { get; private set; }
        protected Stat Constitution { get; private set; }
        protected Stat Intelligence { get; private set; }
        protected Stat Wisdom { get; private set; }
        protected Stat Charisma { get; private set; }

        protected Stat Stamina { get; private set; }
        protected Stat Endurance { get; private set; }
        protected Stat Accuracy { get; private set; }
        protected Stat Reflex { get; private set; }
        protected Stat Vitality { get; private set; }
        protected Stat Fortitude { get; private set; }
        protected Stat Knowledge { get; private set; }
        protected Stat Perception { get; private set; }
        protected Stat Faith { get; private set; }
        protected Stat Will { get; private set; }
        protected Stat Spirit { get; private set; }
        protected Stat Luck { get; private set; }

        protected Stat DodgeDefense { get; private set; }

        //Offense
        public Stat CritChance { get; private set; }
        public Stat CritBonus { get; private set; }
        public Stat AttackSpeed { get; private set; }

        public Stat MeleeAttack { get; private set; }
        public Stat RangedAttack { get; private set; }
        public Stat MagicAttack { get; private set; }

        public Stat SlashingWeapons { get; private set; }
        public Stat BluntWeapons { get; set; }
        public Stat PiercingWeapons { get; private set; }

        //Defense
        public Stat ArmorClass { get; private set; }
        public Stat BlockChance { get; private set; }
        public Stat ParryChance { get; private set; }
        public Stat DodgeChance { get; private set; }

        public Stat BlockBonus { get; private set; }
        public Stat ParryBonus { get; private set; }
        public Stat DodgeBonus { get; private set; }

        public Stat PhysicalDefense { get; private set; }
        public Stat ResistDisease { get; private set; }
        public Stat MagicDefense { get; private set; }
        public Stat ResistEnchantment { get; private set; }

        public Stat Cloth { get; private set; }
        public Stat Leather { get; private set; }
        public Stat Chain { get; private set; }
        public Stat Ring { get; private set; }
        public Stat Scale { get; private set; }
        public Stat Plate { get; private set; }
        public Stat Shields { get; private set; }

        public Stat BluntResist { get; private set; }
        public Stat PierceResist { get; private set; }
        public Stat SlashResist { get; private set; }

        //Support
        public Stat HealingPower { get; private set; }
        public Stat NaturePower { get; private set; }
        public Stat RandomLuck { get; private set; }
        public Stat MaxCarryCapacity { get; private set; }
        public Stat MoveSpeed { get; private set; }

        public int DamageTaken => HitPoints.MaxValue - HitPoints.Value;

        public UnitStats() : base()
        {
            Initialize();
        }

        public UnitStats(int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType, int[] weaponType)
            : base(primary, secondary, defense, element, armorType, weaponType)
        {
            Initialize();
        }

        private void Initialize()
        {
            HitPoints = Major.Stats[MajorFlag.HP];
            Power = Major.Stats[MajorFlag.Power];
            Magic = Major.Stats[MajorFlag.Magic];
            Energy = Major.Stats[MajorFlag.Energy];

            Strength = Primary.Stats[PrimaryFlag.Str];
            Dexterity = Primary.Stats[PrimaryFlag.Dex];
            Constitution = Primary.Stats[PrimaryFlag.Con];
            Intelligence = Primary.Stats[PrimaryFlag.Int];
            Wisdom = Primary.Stats[PrimaryFlag.Wis];
            Charisma = Primary.Stats[PrimaryFlag.Cha];

            Stamina = Secondary.Stats[SecondaryFlag.Stamina];
            Endurance = Secondary.Stats[SecondaryFlag.Endurance];
            Accuracy = Secondary.Stats[SecondaryFlag.Accuracy];
            Reflex = Secondary.Stats[SecondaryFlag.Reflex];
            Vitality = Secondary.Stats[SecondaryFlag.Vitality];
            Fortitude = Secondary.Stats[SecondaryFlag.Fortitude];
            Knowledge = Secondary.Stats[SecondaryFlag.Knowledge];
            Perception = Secondary.Stats[SecondaryFlag.Perception];
            Faith = Secondary.Stats[SecondaryFlag.Faith];
            Will = Secondary.Stats[SecondaryFlag.Will];
            Spirit = Secondary.Stats[SecondaryFlag.Spirit];
            Luck = Secondary.Stats[SecondaryFlag.Luck];

            CritChance = Secondary.Stats[SecondaryFlag.CritChance];
            CritBonus = Secondary.Stats[SecondaryFlag.CritBonus];
            AttackSpeed = Secondary.Stats[SecondaryFlag.AttackSpeed];
            MoveSpeed = Secondary.Stats[SecondaryFlag.MoveSpeed];

            Cloth = ArmorTypes.Stats[ArmorTypeFlag.Cloth];
            Leather = ArmorTypes.Stats[ArmorTypeFlag.Leather];
            Chain = ArmorTypes.Stats[ArmorTypeFlag.Chain];
            Ring = ArmorTypes.Stats[ArmorTypeFlag.Ring];
            Scale = ArmorTypes.Stats[ArmorTypeFlag.Scale];
            Plate = ArmorTypes.Stats[ArmorTypeFlag.Plate];
            Shields = ArmorTypes.Stats[ArmorTypeFlag.Shield];

            SlashingWeapons = WeaponTypes.Stats[WeaponTypeFlag.SlashingWeapons];
            BluntWeapons = WeaponTypes.Stats[WeaponTypeFlag.BluntWeapons];
            PiercingWeapons = WeaponTypes.Stats[WeaponTypeFlag.PiercingWeapons];

            MeleeAttack = Stamina + Strength;
            PhysicalDefense = Endurance + Strength;
            DodgeDefense = Reflex + Dexterity;
            RangedAttack = Accuracy + Dexterity;
            ResistDisease = Fortitude + Constitution;
            MagicAttack = Knowledge + Intelligence;
            MagicDefense = Perception + Intelligence;
            HealingPower = Faith + Wisdom;
            ResistEnchantment = Will + Wisdom;
            NaturePower = Spirit + Charisma;
            RandomLuck = Luck + Charisma;

            DodgeBonus = Defense.Stats[DefenseFlag.DodgeChance] + DodgeDefense;
            BlockBonus = Defense.Stats[DefenseFlag.BlockChance] + PhysicalDefense;
            ParryBonus = Defense.Stats[DefenseFlag.ParryChance] + MeleeAttack;

            DodgeChance = Defense.Stats[DefenseFlag.DodgeChance];

            //Equipment Based
            ArmorClass = Defense.Stats[DefenseFlag.ArmorClass];
            BlockChance = Defense.Stats[DefenseFlag.BlockChance];
            ParryChance = Defense.Stats[DefenseFlag.ParryChance];

            BluntResist = Defense.Stats[DefenseFlag.BluntResist];
            PierceResist = Defense.Stats[DefenseFlag.PierceResist];
            SlashResist = Defense.Stats[DefenseFlag.SlashResist];

            MaxCarryCapacity = new Stat(Strength.Value * 10);
        }

        //public Stat GetUnitArmorClass() { return ArmorClass; }
        //public Stat GetUnitBlockChance() { return BlockChance; }
        //public Stat GetUnitParryChance() { return ParryChance; }

        //public Stat GetUnitBluntResist() { return BluntResist; }
        //public Stat GetUnitPierceResist() { return PierceResist; }
        //public Stat GetUnitSlashResist() { return SlashResist; }

        public int GetBaseStatBonus(PrimaryFlag stat)
        {
            switch (stat)
            {
                case PrimaryFlag.Str:
                    return Strength.Bonus;
                case PrimaryFlag.Dex:
                    return Dexterity.Bonus;
                case PrimaryFlag.Con:
                    return Constitution.Bonus;
                case PrimaryFlag.Int:
                    return Intelligence.Bonus;
                case PrimaryFlag.Wis:
                    return Wisdom.Bonus;
                case PrimaryFlag.Cha:
                    return Charisma.Bonus;
                default:
                    return 0;
            }
        }
    }
}
