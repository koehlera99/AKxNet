using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Units
{
    class LevelTable
    {
        private static int BaseXP = 100;
        private static int MaxLevel = 50;
        private static long[] Levels;

        public LevelTable()
        {
            InitializeLevels();
        }

        private static void InitializeLevels()
        {
            Levels = new long[MaxLevel];

            Levels[0] = BaseXP;

            for (int i = 1; i < MaxLevel; i++)
                Levels[i] = Levels[i - 1] * 2;
        }

        public static long GetNextLevelXP(int currentLevel)
        {
            if (Levels == null)
                InitializeLevels();

            return Levels[currentLevel];
        }
    }
}
