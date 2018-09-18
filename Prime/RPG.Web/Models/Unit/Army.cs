using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Web.Models.Unit
{
    public class Army
    {
        public int ArmyId { get; set; }
        public string ArmyName { get; set; }

        [Display(Name = "Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public List<Platoon> Platoons { get; set; }
    }
}
