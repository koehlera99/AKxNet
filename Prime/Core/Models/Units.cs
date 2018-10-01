using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Units
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? ClassId { get; set; }
        public int? RaceId { get; set; }
        public int? BackgroundId { get; set; }
        public int? SquadId { get; set; }
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

        public Background Background { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }
        public Squads Squad { get; set; }
    }
}
