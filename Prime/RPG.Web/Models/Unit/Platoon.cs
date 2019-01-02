using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG.Web.Models.Unit
{
    public class Platoon
    {
        public int PlatoonId { get; set; }
        public string PlatoonName { get; set; }

        [Display(Name = "Army")]
        public int ArmyId { get; set; }
        public Army Army { get; set; }

        public List<Squad> Squads { get; set; }
    }
}
