using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Items
{
    public class Material : Object
    {
        private List<PhysicalElement> PhysicalElements = new List<PhysicalElement>();

        public HardnessScale GetHardness => (HardnessScale)(int)PhysicalElements.Average(x => (int)x.Hardness);
    }
}
