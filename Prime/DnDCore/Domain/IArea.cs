﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Core.Domain
{
    public interface IArea
    {
        List<ILocation> Locations { get; set; }
    }
}