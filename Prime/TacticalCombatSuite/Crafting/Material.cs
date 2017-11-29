using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.Crafting
{
    class Material
    {
        List<MaterialElement> Elements { get; set; }
        public Scarcity MaterialScarcity { get; set; }

        public Material() { }

    }
}
