using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Effects
{
    public class Property : RPGObject
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public Property() : base(RPGObjectType.Property) { }
    } 
}
