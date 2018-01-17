using System;
using System.Collections.Generic;
using System.Text;
using RPG.Core.Stats;

namespace RPG.Core.Units
{
    interface IUnit : IUnitStats, IAction
    {
        Guid PlayerId { get; set; }
        Guid UnitId { get; set; }
    }
}
