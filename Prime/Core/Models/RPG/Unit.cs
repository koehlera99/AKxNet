using System.ComponentModel.DataAnnotations;

namespace Core.Models.RPG
{
    public class Unit
    {
        public int UnitId { get; set; }

        [Display(Name = "Name")]
        public string UnitName { get; set; }

        public Class Class { get; set; }
        public Race Race { get; set; }
        public Background Background { get; set; }

        [Display(Name = "Squad Name")]
        public int SquadId { get; set; }
        public Squad Squad { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int Stamina { get; set; }
        public int Endurance { get; set; }
        public int Accuracy { get; set; }
        public int Reflex { get; set; }
        public int Vitality { get; set; }
        public int Fortitude { get; set; }
        public int Knowledge { get; set; }
        public int Perception { get; set; }
        public int Faith { get; set; }
        public int Will { get; set; }
        public int Spirit { get; set; }
        public int Luck { get; set; }

        public int CritChance { get; set; }
        public int CritBonus { get; set; }
        public int AttackSpeed { get; set; }
        public int MoveSpeed { get; set; }

        public int Cloth { get; set; }
        public int Leather { get; set; }
        public int Chain { get; set; }
        public int Ring { get; set; }
        public int Scale { get; set; }
        public int Plate { get; set; }
        public int Shields { get; set; }

        public int SlashingWeapons { get; set; }
        public int BluntWeapons { get; set; }
        public int PiercingWeapons { get; set; }

        public int MeleeAttack => Stamina + Strength;
        public int RangedAttack => Accuracy + Dexterity;
        public int MagicAttack => Knowledge + Intelligence;
        public int PhysicalDefense => Endurance + Strength;
        public int ResistDisease => Fortitude + Constitution;
        public int MagicDefense => Perception + Intelligence;
        public int ResistEnchantment => Will + Wisdom;
        public int DodgeDefense => Reflex + Dexterity;
        public int HealingPower => Faith + Wisdom;
        public int NaturePower => Spirit + Charisma;
        public int RandomLuck => Luck + Charisma;

        public Unit() { }
    }
}
