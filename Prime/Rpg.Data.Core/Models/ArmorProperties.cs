using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class ArmorProperties
    {
        [Key]
        [StringLength(25)]
        public string PropertyName { get; set; }
        [Required]
        [StringLength(75)]
        public string PropertyDescription { get; set; }
        public int Flag { get; set; }
    }
}
