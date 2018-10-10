using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class WeaponTypes
    {
        public WeaponTypes()
        {
            Weapons = new HashSet<Weapons>();
        }

        [Key]
        [StringLength(25)]
        public string TypeName { get; set; }
        [Required]
        [StringLength(255)]
        public string TypeDescription { get; set; }

        [InverseProperty("WeaponTypeNavigation")]
        public ICollection<Weapons> Weapons { get; set; }
    }
}
