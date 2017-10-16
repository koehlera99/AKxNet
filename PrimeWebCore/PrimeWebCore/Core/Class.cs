using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeWebCore.Core
{
    public abstract class Class : PrimeObject 
    {
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
