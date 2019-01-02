using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Items
{
    public class PhysicalElement : Object
    {
        public HardnessScale Hardness { get; }
        public int Value { get; }

        public PhysicalElement(int value, HardnessScale hardness)
        {
            Value = value;
            Hardness = hardness;
        }
    }
}
