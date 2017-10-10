﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public class City : DndObject
    {
        public int Population { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
