using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Stats
{
    interface ISecondaryStats
    {
        //Strength atk|def
        int Stamina { get; }        //Physical Attack
        int Endurance { get; }      //Physical Defense

        //Dexterity atk|def
        int Accuracy { get; }       //Ranged Attack
        int Reflex { get; }         //Dodge Defense

        //Constitution  atk|def
        int Vitality { get; }       //Hit Points
        int Fortitude { get; }      //ResistDamageType Disease; Poison

        //Intelligence atk|def
        int Knowledge { get; }      //Magic Attack
        int Perception { get; }     //Magic Defense

        //Wisdom atk|def
        int Faith { get; }          //Healing Power
        int Will { get; }           //ResistDamageType Status Effects

        //Charisma atk|def
        int Spirit { get; }         //Enchantment, Charm
        int Luck { get; }           //Random Luck

        //int Agility { get; }
        //int Reflex { get; }


        ////Con
        //int Stanima { get; }
        //int Endurance { get; }
        //int Vitality { get; }
        //int Fortitude { get; }

        ////Mind
        ////int
        //int Knowledge { get; }
        //int Spirit { get; }
        //int Faith { get; }
        //int Will { get; }


        ////wis
        //int Alertness { get; }
        //int Sanity { get; }
        //int Perception { get; }


        ////cha
        //int Luck { get; }
        //int Fate { get; }
    }
}
