using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Units
    {
        [Key]
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public int? ClassId { get; set; }
        public int? RaceId { get; set; }
        public int? BackgroundId { get; set; }
        [Column("XP")]
        public long Xp { get; set; }
        public short UnitLevel { get; set; }
        public Guid? SquadId { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Units")]
        public Class Class { get; set; }
        [ForeignKey("RaceId")]
        [InverseProperty("Units")]
        public Race Race { get; set; }
        [ForeignKey("SquadId")]
        [InverseProperty("Units")]
        public Squads Squad { get; set; }
        [InverseProperty("Unit")]
        public UnitStats UnitStats { get; set; }
    }
}
