using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.DomainModels
{
    interface IAdventure
    {
        List<IQuest> Quests { get; set; }
    }
}
