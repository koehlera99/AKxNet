using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.RPG.Stats;

namespace TCS.RPG.Combat
{
    class CombatFacilitator
    {
        IEnumerable<DamageObject> DamageObjects { get; set; }

        public static void FacilitateAttack(IOffense offense, IDefense defense)
        {
            if (offense.Melee >= defense.ArmorClass)
            {
                var i = new
                {
                   Id = 0, Name = "Bob"
                };
            }
        }

        public static int FacilitateAttack(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += 3;
                        break;
                    case IEnumerable<object> subList:
                        break;
                    case null:
                        break;
                    default:
                        throw new InvalidOperationException("unknown item type");
                }
            }
            return sum;
        }
    }
}
