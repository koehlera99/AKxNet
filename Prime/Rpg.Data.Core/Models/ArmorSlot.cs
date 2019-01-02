using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class ArmorSlot
    {
        public ArmorSlot()
        {
            Armor = new HashSet<Armor>();
        }

        [Key]
        [Column("ArmorSlot")]
        [StringLength(15)]
        public string ArmorSlot1 { get; set; }
        [Required]
        [StringLength(35)]
        public string SlotDescription { get; set; }

        [InverseProperty("ArmorSlotNavigation")]
        public ICollection<Armor> Armor { get; set; }
    }
}
