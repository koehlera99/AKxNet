using System;

namespace RPG.Core.Combat
{
    class DamageObject : IDamage
    {
        public int DamageAmount { get; set; }
        public PrimaryDamageType DamageType { get; set; }

        public IDamage GetDamage()
        {
            throw new NotImplementedException();
        }
    }
}
