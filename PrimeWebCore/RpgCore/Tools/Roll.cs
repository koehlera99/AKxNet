using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Tools
{
    /// <summary>
    /// Generate random dice rolls
    /// multiplier = number of rolls
    /// Typical polyhedral dice (Ex: D20 = 1 thru 20)
    /// </summary>
    static class Roll
    {
        private static Random random = new Random();

        public static int D2(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 3);

            return value;
        }

        public static int D3(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 4);

            return value;
        }

        public static int D4(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 5);

            return value;
        }

        public static int D6(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 7);

            return value;
        }
        public static int D8(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 9);

            return value;
        }

        public static int D10(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 11);

            return value;
        }

        public static int D12(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 13);

            return value;
        }

        public static int D20(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 21);

            return value;
        }

        public static int D100(int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, 101);

            return value;
        }

        public static int Dice(int die, int multiplier = 1)
        {
            int value = 0;

            for (int i = 0; i < multiplier; i++)
                value += random.Next(1, die + 1);

            return value;
        }

        /// <summary>
        /// Standard attack roll: D20 + Attack modifier
        /// </summary>
        /// <param name="modifier">modifier added to each attack roll</param>
        /// <returns></returns>
        public static int AttackRoll(int modifier = 0)
        {
            return D100() + modifier;
        }




    }
}
