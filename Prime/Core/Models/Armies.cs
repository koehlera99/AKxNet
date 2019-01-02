using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Armies
    {
        public Armies()
        {
            Platoons = new HashSet<Platoons>();
        }

        public int ArmyId { get; set; }
        public string ArmyName { get; set; }
        public int PlayerId { get; set; }

        public Players Player { get; set; }
        public ICollection<Platoons> Platoons { get; set; }
    }
}
