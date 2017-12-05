using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Combat
{
    class DamageObject : IDamageObject
    {
        public int DamageAmount { get; set; }
        public DamageType DamageType { get; set; }
    }

    enum DamageType
    {
        Weapon,
        Magic
    }

    interface IDamageObject
    {
        int DamageAmount { get; set; }
        DamageType DamageType { get; set; }
    }

    
}
