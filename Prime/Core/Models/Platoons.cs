using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Platoons
    {
        public Platoons()
        {
            Squads = new HashSet<Squads>();
        }

        public int PlatoonId { get; set; }
        public string PlatoonName { get; set; }
        public int ArmyId { get; set; }

        public Armies Army { get; set; }
        public ICollection<Squads> Squads { get; set; }
    }
}
