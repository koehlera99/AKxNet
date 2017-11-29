using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Items
{
    public class Element : Object
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public Element() { }
    }

    [Flags]
    public enum DamageElements
    {
        None = 0,
        Fire = 1,           //burn (Fire DOT)
        Electric = 2,       //stun
        Bio = 4,            //poison, exhaustion
        Force = 8,          //move
        Radiant = 16,       //blind
        Shadow = 32,        //sleep
        Ice = 64            //Slow
    }

    public enum HardnessScale
    {
        Tin,
        Silver,
        Platinum,
        Iron,
        Steel,
        Cobalt,
        Titanium,
        Silicon,
        Quartz,
        Emerald,
        Chromium,
        Diamond
    }
}
