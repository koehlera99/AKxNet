using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Class
    {
        public Class()
        {
            Units = new HashSet<Units>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        [InverseProperty("Class")]
        public ICollection<Units> Units { get; set; }
    }
}
