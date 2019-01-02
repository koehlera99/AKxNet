using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Race
    {
        public Race()
        {
            Units = new HashSet<Units>();
        }

        public int RaceId { get; set; }
        public string RaceName { get; set; }

        public ICollection<Units> Units { get; set; }
    }
}
