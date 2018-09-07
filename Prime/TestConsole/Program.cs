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

            unit.RemoveCondition(Condition.Berserk);
            unit.AddCondition(Condition.Berserk);
            unit.AddCondition(Condition.Confused);
            unit.AddCondition(Condition.Berserk);
            unit.RemoveCondition(Condition.Berserk);


        }
    }


}
