using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeWebCore.Core;

namespace PrimeWebCore.Models
{
    public class Item : PrimeObject
    {
        public int Weight { get; set; }
        public Money Value { get; set; }

        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}
