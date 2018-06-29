using System;
using System.Collections.Generic;
using System.Text;
using RPG.Standard.Stats;

namespace RPG.Standard.Units
{
    interface IUnit : IUnitStats, IAction
    {
        Guid PlayerId { get; set; }
        Guid UnitId { get; set; }
    }
}
