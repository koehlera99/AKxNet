using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDWeb.DomainModels
{
    interface ILocation
    {
        List<IStructure> Structures { get; set; }
        List<IAdventure> Adventures { get; set; }
        ICampaign Campaign { get; set; }
        List<Npc> Npcs { get; set; }
    }
}
