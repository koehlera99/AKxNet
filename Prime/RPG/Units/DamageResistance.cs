﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG.Core.Items;
using RPG.Core.Items.Offense;

namespace RPG.Core.Units
{
    public class DamageResistance
    {
        public string DamageTypeName { get; }
        public DamageTypes DamageType { get; }
        public int Value { get; set; }
        public Object Source { get; set; }

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

        public DamageResistance(string name, int value, Object source)
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

        public DamageResistance(DamageTypes damageType, int value, Object source)
        {
            DamageType = damageType;
            Value = value;
            Source = source;
        }
    }
}
