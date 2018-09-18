using System.Collections.Generic;

namespace RPG.Web.Models.Unit
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public List<Army> Armies { get; set; }
    }
}
