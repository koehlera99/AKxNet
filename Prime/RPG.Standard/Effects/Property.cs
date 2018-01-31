using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core.Effects
{
    public class Property : Object
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public Property() { }
    }
}
