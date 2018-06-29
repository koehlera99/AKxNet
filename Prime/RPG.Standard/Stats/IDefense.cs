using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Stats
{
    interface IDefense
    {
        //Strength
        int ArmorClass { get; }
        int Block { get; }

        //Dexterity
        int Dodge { get; }
        int Parry { get; }

        //Wisdom; Intelligence; Charisma
        int Willpower { get; }

        //Constitution
        int Immunity { get; }
    }
}
