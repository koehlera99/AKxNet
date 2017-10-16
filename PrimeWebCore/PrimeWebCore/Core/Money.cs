using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeWebCore.Core
{
    public class Money
    {
        public int Platinum { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        public double TotalPlatinum()
        {
            return Platinum + (Gold / 10) + (Silver / 100) + (Copper / 1000);
        }

        public double TotalGold()
        {
            return (Platinum * 10) + Gold + (Silver / 10) + (Copper / 100);
        }

        public double TotalSilver()
        {
            return (Platinum * 100) + (Gold * 10) + Silver  + (Copper / 10);
        }

        public int TotalCopper()
        {
            return (Platinum * 1000) + (Gold * 100) + (Silver * 10) + Copper;
        }
    }
}
