using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class ArmorType
    {
        public ArmorType()
        {
            Armor = new HashSet<Armor>();
        }

        [Key]
        [Column("ArmorType")]
        [StringLength(25)]
        public string ArmorType1 { get; set; }
        [Required]
        [StringLength(75)]
        public string TypeDescription { get; set; }

        [InverseProperty("ArmorTypeNavigation")]
        public ICollection<Armor> Armor { get; set; }
    }
}
