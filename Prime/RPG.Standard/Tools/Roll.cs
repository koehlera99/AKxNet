using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Tools
{
    /// <summary>
    /// Generate random dice rolls
    /// multiplier = number of rolls
    /// Typical polyhedral dice (Ex: d20 = 1 thru 20)
    /// </summary>
    public static class Roll
    {
        private static Random random = new Random();

        public static bool Coin
        {
            get { return random.Next(0, 2) == 0 ? false : true; }
        }

        public static int d4
        {
            get { return random.Next(0, 4) + 1; }
        }

        public static int d6
        {
            get { return random.Next(0, 6) + 1; }
        }

        public static int d8
        {
            get { return random.Next(0, 8) + 1; }
        }

        public static int d10
        {
            get { return random.Next(0, 10) + 1; }
        }

        public static int d12
        {
            get { return random.Next(0, 12) + 1; }
        }

        public static int d20
        {
            get { return random.Next(0, 20) + 1; }
        }

        public static int d100
        {
            get { return random.Next(0, 100) + 1; }
        }

        public static int d1000
        {
            get { return random.Next(0, 1000) + 1; }
        }

        public static int D4 => random.Next(0, 4) + 1;
        public static int D6 => random.Next(0, 6) + 1;
        public static int D8 => random.Next(0, 8) + 1;
        public static int D10 => random.Next(0, 10) + 1;
        public static int D12 => random.Next(0, 12) + 1;
        public static int D20 => random.Next(0, 20) + 1;
        public static int D100 => random.Next(0, 100) + 1;
        public static int D1000 => random.Next(0, 1000) + 1;

        public static int Dice(int die, int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, die) + 1;

            return value;
        }

        public static int Dice(Die die, int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, (int)die + 1);

            return value;
        }

        /// <summary>
        /// Standard attack roll: D20 + Attack modifier
        /// </summary>
        /// <param name="modifier">modifier added to each attack roll</param>
        /// <returns></returns>
        public static int AttackRoll(int modifier = 0)
        {
            return d20 + modifier;
        }
    }

    public enum Die
    {
        D2 = 2,
        D3 = 3,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100

    }
}
