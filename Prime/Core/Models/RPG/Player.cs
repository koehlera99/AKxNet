using System.Collections.Generic;

namespace Core.Models.RPG
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public List<Army> Armies { get; set; }
    }
}
