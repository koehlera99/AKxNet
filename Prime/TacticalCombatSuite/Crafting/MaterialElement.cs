using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.Common;

namespace TCS.Crafting
{
    class MaterialElement
    {
        private uint _quantity = 1;

        public DifficultyLevel ExtractionDifficulty;

        public Element ElementInMaterial { get; set; }
        public uint Quantity
        {
            get { return _quantity; }
            set { _quantity = (value > 0) ? value : 1; }
        }

        public MaterialElement() { }
        public MaterialElement(Element element)
        {
            ElementInMaterial = element;
        }
        public MaterialElement(Element element, uint quantity)
        {
            ElementInMaterial = element;
            Quantity = quantity;
        }

    }

}
