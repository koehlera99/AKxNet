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

            unit.Remove(Condition.Berserk);
            unit.Set(Condition.Berserk);
            unit.Set(Condition.Confused);
            unit.Set(Condition.Berserk);
            unit.Remove(Condition.Berserk);


        }
    }


}
