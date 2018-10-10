using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Armor
    {
        public Guid ArmorId { get; set; }
        [Required]
        [StringLength(35)]
        public string ArmorName { get; set; }
        [Required]
        [StringLength(75)]
        public string ArmorDescription { get; set; }
        public byte Hardness { get; set; }
        public byte ArmorClass { get; set; }
        public byte ResistBlunt { get; set; }
        public byte ResistSlashing { get; set; }
        public byte ResistPiercing { get; set; }
        public byte DefenseBonus { get; set; }
        public byte MaxDexReduction { get; set; }
        [Required]
        [StringLength(25)]
        public string ArmorType { get; set; }
        public int ArmorPropertyFlag { get; set; }
        [StringLength(15)]
        public string ArmorSlot { get; set; }

        [ForeignKey("ArmorId")]
        [InverseProperty("InverseArmorNavigation")]
        public Armor ArmorNavigation { get; set; }
        [ForeignKey("ArmorSlot")]
        [InverseProperty("Armor")]
        public ArmorSlot ArmorSlotNavigation { get; set; }
        [ForeignKey("ArmorType")]
        [InverseProperty("Armor")]
        public ArmorType ArmorTypeNavigation { get; set; }
        [InverseProperty("ArmorNavigation")]
        public Armor InverseArmorNavigation { get; set; }
    }
}
