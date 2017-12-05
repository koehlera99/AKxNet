using System;

namespace RPG.Core.Items.Offense
{
    class DamageObject : IDamage
    {
        public int DamageAmount { get; set; }
        public DamageType DamageType { get; set; }

        public IDamage GetDamage()
        {
            throw new NotImplementedException();
        }
    }
}
