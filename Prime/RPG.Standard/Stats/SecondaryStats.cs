using System;

namespace RPG.Core.Stats
{
    [Obsolete]
    class SecondaryStats
    {
        //Strength atk|def
        public int Stamina { get; set; }        //Physical Attack
        public int Endurance { get; set; }      //Physical Defense

        //Dexterity atk|def
        public int Accuracy { get; set; }       //Ranged Attack
        public int Reflex { get; set; }         //Dodge Defense

        //Constitution  atk|def
        public int Vitality { get; set; }       //Hit Points
        public int Fortitude { get; set; }      //ResistDamageType Disease; Poison

        //Intelligence atk|def
        public int Knowledge { get; set; }      //Magic Attack
        public int Perception { get; set; }     //Magic Defense

        //Wisdom atk|def
        public int Faith { get; set; }          //Healing Power
        public int Will { get; set; }           //ResistDamageType Status Effects

        //Charisma atk|def
        public int Spirit { get; set; }         //Enchantment, Charm
        public int Luck { get; set; }           //Random Luck
    }

    [Obsolete]
    class Stat
    {
        public int Dodge;
        public int Block;
        public int Accuracy;

    }


}
