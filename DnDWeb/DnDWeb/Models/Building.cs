﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.Models
{
    public class Building : DndObject
    {
        public List<Room> Rooms { get; set; }
    }
}
