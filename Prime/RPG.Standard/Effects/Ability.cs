using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard
{
    public class Ability : Object
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public AbilityHandler AbilityFunction { get; set; }

        public Ability() { }
        public Ability(int id, string name, int value, string description, AbilityHandler function)
        {
            this.Id = id;
            this.Name = name;
            this.Value = value;
            this.Description = description;
            this.AbilityFunction = function;
        }

    }

    public class AbilityArgs
    {
        public Object Caster { get; set; }
        public int Value { get; set; }
        public string[] Args { get; set; } = null;

        public AbilityArgs(Object caster)
        {
            Caster = caster;
        }

        public AbilityArgs(Object caster, int value)
        {
            Caster = caster;
            Value = value;
        }

        public AbilityArgs(Object caster, int value, string[] args)
        {
            Caster = caster;
            Value = value;
            Args = args;
        }
    }

    public delegate void AbilityHandler(List<AbilityArgs> args);

    //delegate void AbilityHandler(params AbilityArgs[] args);







}
