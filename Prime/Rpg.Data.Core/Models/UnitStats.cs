using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class UnitStats
    {
        [Key]
        public Guid UnitId { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public byte Stamina { get; set; }
        public byte Endurance { get; set; }
        public byte Accuracy { get; set; }
        public byte Reflex { get; set; }
        public byte Vitality { get; set; }
        public byte Fortitude { get; set; }
        public byte Knowledge { get; set; }
        public byte Perception { get; set; }
        public byte Faith { get; set; }
        public byte Will { get; set; }
        public byte Spirit { get; set; }
        public byte Luck { get; set; }
        public byte CritChance { get; set; }
        public byte CritBonus { get; set; }
        public byte AttackSpeed { get; set; }
        public byte MoveSpeed { get; set; }
        public byte Cloth { get; set; }
        public byte Leather { get; set; }
        public byte Chain { get; set; }
        public byte Ring { get; set; }
        public byte Scale { get; set; }
        public byte Plate { get; set; }
        public byte Shields { get; set; }
        public byte SlashingWeapons { get; set; }
        public byte BluntWeapons { get; set; }
        public byte PiercingWeapons { get; set; }

        [ForeignKey("UnitId")]
        [InverseProperty("UnitStats")]
        public Units Unit { get; set; }
    }
}
