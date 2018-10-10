using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class WeaponDamageTypes
    {
        public WeaponDamageTypes()
        {
            Weapons = new HashSet<Weapons>();
        }

        [Key]
        [StringLength(10)]
        public string DamageTypeName { get; set; }
        [Required]
        [StringLength(35)]
        public string DamageTypeDescription { get; set; }

        [InverseProperty("WeaponDamageTypeNavigation")]
        public ICollection<Weapons> Weapons { get; set; }
    }
}
