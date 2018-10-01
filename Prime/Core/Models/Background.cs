using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Background
    {
        public Background()
        {
            Units = new HashSet<Units>();
        }

        public int BackgroundId { get; set; }
        public string BackgroundName { get; set; }

        public ICollection<Units> Units { get; set; }
    }
}
