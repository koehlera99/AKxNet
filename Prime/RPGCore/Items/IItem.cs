using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Core.Items
{
    public interface IItem
    {
        float Size { get; set; }
        float Weight { get; set; }
        IEnumerable<Material> Materials { get; set; }
        IEnumerable<IItem> Items { get; set; }
    }
}
