using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Base.Stats
{
    interface IStats
    {
        Dictionary<Major, int> BaseStats { get; set; }
        Dictionary<Primary, int> PrimaryStats { get; set; }
        Dictionary<Secondary, int> SecondaryStats { get; set; }
        Dictionary<Defense, int> DefenseStats { get; set; }
        Dictionary<Element, int> ElementDefense { get; set; }
        Dictionary<ArmorType, int> ArmorType { get; set; }
        Condition Conditions { get; set; }
    }
}
