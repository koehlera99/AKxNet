using RPG.Standard.Base;
using RPG.Standard.Base.Stats;
using RPG.Standard.Effects;
using RPG.Standard.Items;
using RPG.Standard.Items.Defense;
using RPG.Standard.Items.Offense;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RPG.Standard.Units
{
    public abstract class UnitStats : UnitBase
    {
        protected Stat HitPoints;
        protected Stat Power;
        protected Stat Magic;
        protected Stat Energy;

        protected Stat Strength;
        protected Stat Dexterity;
        protected Stat Constitution;
        protected Stat Intelligence;
        protected Stat Wisdom;
        protected Stat Charisma;

        protected Stat Stamina;
        protected Stat Endurance;
        protected Stat Accuracy;
        protected Stat Reflex;
        protected Stat Vitality;
        protected Stat Fortitude;
        protected Stat Knowledge;
        protected Stat Perception;
        protected Stat Faith;
        protected Stat Will;
        protected Stat Spirit;
        protected Stat Luck;

        protected Stat CritChance;
        protected Stat CritBonus;
        protected Stat AttackSpeed;
        protected Stat MoveSpeed;

        protected Stat Cloth;
        protected Stat Leather;
        protected Stat Chain;
        protected Stat Ring;
        protected Stat Scale;
        protected Stat Plate;
        protected Stat Shields;

        protected Stat MeleeAttack;
        protected Stat RangedAttack;
        protected Stat DodgeDefense;
        protected Stat PhysicalDefense;

        protected Stat ResistDisease;
        protected Stat MagicAttack;
        protected Stat MagicDefense;
        protected Stat HealingPower;
        protected Stat ResistEnchantment;
        protected Stat NaturePower;
        protected Stat RandomLuck;

        protected Stat ArmorClass;
        protected Stat Block;
        protected Stat Dodge;
        protected Stat Parry;

        public Stat SlashingWeapons { get; set; }
        public Stat BluntWeapons { get; set; }
        public Stat PiercingWeapons { get; set; }

        public Stat MaxCarryCapacity { get; private set; }

        public int DamageTaken => HitPoints.MaxValue - HitPoints.Value;



        public List<Effect> CurrentEffects { get; set; } = new List<Effect>();

        [DebuggerStepThrough]
        public int Effects(string name)
        {
            RefreshEffects();

            return CurrentEffects.Where(x => x.Name.ToUpper() == name.ToUpper()).Sum(x => x.Value);
        }

        public void RefreshEffects()
        {
            if (CurrentEffects == null)
                CurrentEffects = new List<Effect>();

            foreach (Effect e in CurrentEffects)
                e.Refresh();

            CurrentEffects.RemoveAll(CurrentEffects => CurrentEffects.IsActive == false);
        }

        public UnitStats() : base()
        {
            Initialize();
        }

        public UnitStats(int[] major, int[] primary, int[] secondary, int[] defense, int[] element, int[] armorType) 
            : base(major, primary, secondary, defense, element, armorType)
        {
            Initialize();
        }

        private void Initialize()
        {
            HitPoints = Get(Major.HP);
            Power = Get(Major.Power);
            Magic = Get(Major.Magic);
            Energy = Get(Major.Energy);

            Strength = Get(Primary.Str);
            Dexterity = Get(Primary.Dex);
            Constitution = Get(Primary.Con);
            Intelligence = Get(Primary.Int);
            Wisdom = Get(Primary.Wis);
            Charisma = Get(Primary.Cha);

            Stamina = Get(Secondary.Stamina);
            Endurance = Get(Secondary.Endurance);
            Accuracy = Get(Secondary.Accuracy);
            Reflex = Get(Secondary.Reflex);
            Vitality = Get(Secondary.Vitality);
            Fortitude = Get(Secondary.Fortitude);
            Knowledge = Get(Secondary.Knowledge);
            Perception = Get(Secondary.Perception);
            Faith = Get(Secondary.Faith);
            Will = Get(Secondary.Will);
            Spirit = Get(Secondary.Spirit);
            Luck = Get(Secondary.Luck);

            CritChance = Get(Secondary.CritChance);
            CritBonus = Get(Secondary.CritBonus);
            AttackSpeed = Get(Secondary.AttackSpeed);
            MoveSpeed = Get(Secondary.MoveSpeed);

            Cloth = Get(ArmorType.Cloth);
            Leather = Get(ArmorType.Leather);
            Chain = Get(ArmorType.Chain);
            Ring = Get(ArmorType.Ring);
            Scale = Get(ArmorType.Scale);
            Plate = Get(ArmorType.Plate);
            Shields = Get(ArmorType.Shield);

            MeleeAttack = Stamina + Strength;
            PhysicalDefense = Endurance + Strength;
            RangedAttack = Accuracy + Dexterity;
            DodgeDefense = Reflex + Dexterity;

            ResistDisease = Fortitude + Constitution;
            MagicAttack = Knowledge + Intelligence;
            MagicDefense = Perception + Intelligence;
            HealingPower = Faith + Wisdom;
            ResistEnchantment = Will + Wisdom;
            NaturePower = Spirit + Charisma;
            RandomLuck = Luck + Charisma;

            ArmorClass = Get(Defense.AC);
            Block = Get(Defense.Block) + PhysicalDefense;
            Dodge = Get(Defense.Dodge) + DodgeDefense;
            Parry = Get(Defense.Parry) + MeleeAttack;

            MaxCarryCapacity = new Stat(Strength.Value * 10);
        }
    }
}
