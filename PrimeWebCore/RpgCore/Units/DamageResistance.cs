using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.RPG.Items;

namespace TCS.RPG.Units
{
    public class DamageResistance
    {
        public string DamageTypeName { get; }
        public DamageTypes DamageType { get; }
        public int Value { get; set; }
        public RPGObject Source { get; set; }

        /// <summary>
        /// Constructors using 'string' as damageType
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public DamageResistance(string name, int value)
        {
            DamageTypeName = name;
            Value = value;
        }

        public DamageResistance(string name, int value, RPGObject source)
        {
            DamageTypeName = name;
            Value = value;
            Source = source;
        }
        /// <summary>
        /// Constructors using 'enum' as damageType
        /// </summary>
        /// <param name="damageType"></param>
        /// <param name="value"></param>
        public DamageResistance(DamageTypes damageType, int value)
        {
            DamageType = damageType;
            Value = value;
        }

        public DamageResistance(DamageTypes damageType, int value, RPGObject source)
        {
            DamageType = damageType;
            Value = value;
            Source = source;
        }
    }
}
