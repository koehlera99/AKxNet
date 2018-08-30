using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Effects
{
    class Conditions
    {
        public ConditionTypes ConditionType { get; set; }
        public int Rounds { get; set; }

        public int TTL = 0;
        public readonly int OriginalTTL;


        private DateTime Created;
        public TimeSpan Duration;
        public bool IsActive = true;

        public Conditions(int timeToLive)
        {
            OriginalTTL = timeToLive;
        }

        public void Refresh()
        {
            TimeSpan t = DateTime.Now - Created;
            TTL = OriginalTTL - t.Seconds;

            if (t.Seconds > Duration.Seconds)
            {
                IsActive = false;
            }
        }
    }

    enum ConditionTypes
    {
        Bleed,      //Slashing, Fire
        Stun,       //Blunt, Electric
        Poison,     //Bio
        Exhaustion, //Drain, Bio
        Blind,      //Radiant
        Sleep,      //Shadow
        Slow,       //Ice, Time
        Haste,      //Time
        Silence,    //Thunder, Sound

        Berserk,    //Mind: Fight Everything
        Charm,      //Mind: Fight for me
        Confuse,    //Mind: Fight Randomly
        Fear        //Mind: Don't fight

    }
}
