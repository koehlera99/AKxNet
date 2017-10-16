using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeWebCore.Core
{
    interface IAction
    {
        IAction Use();
    }
}
