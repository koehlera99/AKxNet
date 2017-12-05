using System.Collections.Generic;

namespace DnD.Core.Domain
{
    public interface IAdventure
    {
        List<IQuest> Quests { get; set; }
    }
}
