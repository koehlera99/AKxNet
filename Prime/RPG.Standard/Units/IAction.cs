using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Standard.Units
{
    public interface IAction
    {
        bool PerformAction(ActionType actionType);
    }

    public enum ActionType
    {
        WeaponAttack,
        CastSpell,
        UseItem,
        UsePower,
        Move
    }
}
