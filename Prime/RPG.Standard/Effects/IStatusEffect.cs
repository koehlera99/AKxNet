﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Effects
{
    public interface IStatusEffect
    {
        int TimeToLive { get; set; }
    }
}
