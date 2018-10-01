using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Players
    {
        public Players()
        {
            Armies = new HashSet<Armies>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ICollection<Armies> Armies { get; set; }
    }
}
