using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Armies
    {
        public Armies()
        {
            Platoons = new HashSet<Platoons>();
        }

        [Key]
        public Guid ArmyId { get; set; }
        public string ArmyName { get; set; }
        public Guid? PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Armies")]
        public Players Player { get; set; }
        [InverseProperty("Army")]
        public ICollection<Platoons> Platoons { get; set; }
    }
}
