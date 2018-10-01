using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Class
    {
        public Class()
        {
            Units = new HashSet<Units>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<Units> Units { get; set; }
    }
}
