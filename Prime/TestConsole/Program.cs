using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Standard.Base;
using RPG.Standard.Units;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit unit = new Unit();

            unit.Stats.RemoveCondition(Condition.Berserk);
            unit.Stats.AddCondition(Condition.Berserk);
            unit.Stats.AddCondition(Condition.Confused);
            unit.Stats.AddCondition(Condition.Berserk);
            unit.Stats.RemoveCondition(Condition.Berserk);


        }
    }


}
