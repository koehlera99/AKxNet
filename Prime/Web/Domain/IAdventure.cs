﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain
{
    public interface IAdventure
    {
        List<IQuest> Quests { get; set; }
    }
}