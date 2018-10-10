using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Players
    {
        public Players()
        {
            Armies = new HashSet<Armies>();
        }

        [Key]
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        [StringLength(35)]
        public string UserName { get; set; }
        [StringLength(35)]
        public string Password { get; set; }
        public long? Gems { get; set; }
        [Column("XP")]
        public long? Xp { get; set; }

        [InverseProperty("Player")]
        public ICollection<Armies> Armies { get; set; }
    }
}
