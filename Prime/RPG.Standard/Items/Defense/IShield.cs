using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Items.Defense
{
    interface IShield
    {
        int AC { get; set; }
        int Block { get; set; }
    }
}
