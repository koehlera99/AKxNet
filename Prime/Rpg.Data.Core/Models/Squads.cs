using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Squads
    {
        public Squads()
        {
            Units = new HashSet<Units>();
        }

        [Key]
        public Guid SquadId { get; set; }
        public string SquadName { get; set; }
        public Guid? PlatoonId { get; set; }

        [ForeignKey("PlatoonId")]
        [InverseProperty("Squads")]
        public Platoons Platoon { get; set; }
        [InverseProperty("Squad")]
        public ICollection<Units> Units { get; set; }
    }
}
