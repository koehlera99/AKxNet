using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Platoons
    {
        public Platoons()
        {
            Squads = new HashSet<Squads>();
        }

        [Key]
        public Guid PlatoonId { get; set; }
        public string PlatoonName { get; set; }
        public Guid? ArmyId { get; set; }

        [ForeignKey("ArmyId")]
        [InverseProperty("Platoons")]
        public Armies Army { get; set; }
        [InverseProperty("Platoon")]
        public ICollection<Squads> Squads { get; set; }
    }
}
