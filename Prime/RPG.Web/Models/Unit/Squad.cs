using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG.Web.Models.Unit
{
    public class Squad
    {
        public int SquadId { get; set; }
        public string SquadName { get; set; }

        [Display(Name = "Platoon")]
        public int PlatoonId { get; set; }
        public Platoon Platoon { get; set; }

        public List<Unit> Units { get; set; }
    }
}
