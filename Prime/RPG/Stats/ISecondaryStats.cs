namespace RPG.Core.Stats
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
    }
}
