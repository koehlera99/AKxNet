using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG
{
    public class Ability : RPGObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public AbilityHandler AbilityFunction { get; set; }

        public Ability() : base(RPGObjectType.Ability) { }
        public Ability(int id, string name, int value, string description, AbilityHandler function) : base(RPGObjectType.Ability)
        {
            this.ID = id;
            this.Name = name;
            this.Value = value;
            this.Description = description;
            this.AbilityFunction = function;
        }
        
    }

    public class AbilityArgs
    {
        public RPGObject Caster { get; set; }
        public int Value { get; set; }
        public string[] Args { get; set; } = null;

        public AbilityArgs(RPGObject caster)
        {
            Caster = caster;
        }

        public AbilityArgs(RPGObject caster, int value)
        {
            Caster = caster;
            Value = value;
        }

        public AbilityArgs(RPGObject caster, int value, string[] args)
        {
            Caster = caster;
            Value = value;
            Args = args;
        }
    }

    public delegate void AbilityHandler(List<AbilityArgs> args);

    //delegate void AbilityHandler(params AbilityArgs[] args);







}
