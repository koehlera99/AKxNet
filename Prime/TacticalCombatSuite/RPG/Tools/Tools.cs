using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.RPG.Effects;

namespace TCS.RPG.Tools
{
    static class Tools
    {
        public static List<Ability> AbilityList { get; set; } = new List<Ability>();

        public static void FillAbilityList()
        {
            //AddAbilityListItem();
        }

        private static void AddAbilityListItem(int id, string name, int value, string description, AbilityHandler function)
        {
            Ability a = new Ability(id, name, value, description, function);
            AbilityList.Add(a);
        }

        public static void UseAbility(int ablitiyID, Object caster)
        {
            if (AbilityList.Count > 0)
            {
                var abilities =
                    from ability in AbilityList
                    where ability.ID == ablitiyID
                    select ability;

                foreach (var a in abilities)
                {
                    a.AbilityFunction.Invoke(new List<AbilityArgs>() { new AbilityArgs(caster) });
                }
            }
        }
    }

    
}
