﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Core.Domain
{
    public interface ICampaign
    {
        List<IArea> Areas { get; set; }
    }
}
