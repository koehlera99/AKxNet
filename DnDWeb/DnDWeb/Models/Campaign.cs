﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public class Campaign : DndObject
    {
        public List<Location> Locations { get; set; }
        public List<City> Cities { get; set; }
    }
}
