using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.RPG
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
