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

        public static int D4(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 4) + 1;

            return value;
        }

        public static int D6(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 6) + 1;

            return value;
        }

        public static int D8(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 8) + 1;

            return value;
        }

        public static int D10(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 10) + 1;

            return value;
        }

        public static int D12(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 12) + 1;

            return value;
        }

        public static int D20(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 20) + 1;

            return value;
        }

        public static int D100(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 100) + 1;

            return value;
        }

        public static int D1000(int multiplier)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, 1000) + 1;

            return value;
        }

        public static int Dice(int die, int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(0, die) + 1;

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
}
