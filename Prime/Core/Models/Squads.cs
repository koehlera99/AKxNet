using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Squads
    {
        public Squads()
        {
            Units = new HashSet<Units>();
        }

        public int SquadId { get; set; }
        public string SquadName { get; set; }
        public int PlatoonId { get; set; }

        public Platoons Platoon { get; set; }
        public ICollection<Units> Units { get; set; }
    }
}
