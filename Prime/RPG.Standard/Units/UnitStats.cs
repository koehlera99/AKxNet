using RPG.Standard.Base;
using RPG.Standard.Base.Stats;

namespace RPG.Standard.Units
{
    public abstract class UnitStats : UnitBase
    {
        protected int HitPoints => Get(Major.HP);
        protected int Power => Get(Major.Power);
        protected int Magic => Get(Major.Magic);
        protected int Energy => Get(Major.Energy);

        protected int MaxPower => Strength + Dexterity + Constitution + PowerBonus();
        protected int MaxMagic => Intelligence + Wisdom + Charisma + MagicBonus();
        protected int MaxEnergy => Get(Major.Energy);

        protected int Strength => Get(Primary.Str);
        protected int Dexterity => Get(Primary.Dex);
        protected int Constitution => Get(Primary.Con);
        protected int Intelligence => Get(Primary.Int);
        protected int Wisdom => Get(Primary.Wis);
        protected int Charisma => Get(Primary.Cha);

        protected int Stamina => Get(Secondary.Stamina);
        protected int Endurance => Get(Secondary.Endurance);
        protected int Accuracy => Get(Secondary.Accuracy);
        protected int Reflex => Get(Secondary.Reflex);
        protected int Vitality => Get(Secondary.Vitality);
        protected int Fortitude => Get(Secondary.Fortitude);
        protected int Knowledge => Get(Secondary.Knowledge); 
        protected int Perception => Get(Secondary.Perception); 
        protected int Faith => Get(Secondary.Faith);
        protected int Will => Get(Secondary.Will);
        protected int Spirit => Get(Secondary.Spirit);
        protected int Luck => Get(Secondary.Luck);

        protected int CritChance => Get(Secondary.CritChance);
        protected int CritBonus => Get(Secondary.CritBonus);
        protected int AttackSpeed => Get(Secondary.AttackSpeed);
        protected int MoveSpeed => Get(Secondary.MoveSpeed);

        protected int ArmorClass => Get(Defense.AC);
        protected int Block => Get(Defense.Block) + PhysicalDefense;
        protected int Dodge => Get(Defense.Dodge) + DodgeDefense;
        protected int Parry => Get(Defense.Parry) + MeleeAttack;

        protected int MeleeAttack => Stamina + Strength;
        protected int PhysicalDefense => Endurance + Strength;
        protected int RangedAttack => Accuracy + Dexterity;
        protected int DodgeDefense => Reflex + Dexterity;
        protected int MaxHitPoints => Vitality + Constitution;
        protected int ResistDisease => Fortitude + Constitution;
        protected int MagicAttack => Knowledge + Intelligence;
        protected int MagicDefense => Perception + Intelligence;
        protected int HealingPower => Faith + Wisdom;
        protected int ResistEnchantment => Will + Wisdom;
        protected int NaturePower => Spirit + Charisma;
        protected int RandomLuck => Luck + Charisma;

        protected int Cloth => Get(ArmorType.Cloth);
        protected int Leather => Get(ArmorType.Leather);
        protected int Chain => Get(ArmorType.Chain);
        protected int Ring => Get(ArmorType.Ring);
        protected int Scale => Get(ArmorType.Scale);
        protected int Plate => Get(ArmorType.Plate);
        protected int Shields => Get(ArmorType.Shield);
    }
}
