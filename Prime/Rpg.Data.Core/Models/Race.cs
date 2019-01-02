using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Race
    {
        public Race()
        {
            Units = new HashSet<Units>();
        }

        public int RaceId { get; set; }
        public string RaceName { get; set; }

        [InverseProperty("Race")]
        public ICollection<Units> Units { get; set; }
    }
}
