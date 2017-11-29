using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TCS.Common;

namespace TCS.Crafting
{
    class Scarcity
    {

        public const int MaxValue = 10000;
        public const int MinValue = 1;

        private const int RollMax = 5;
        private const short MaxStartingLevel = 5;

        public float ChanceToFind
        {
            get
            {
                return GetChanceToFind(ScarcityValue);
            }
        }

        public string ChanceToFindString
        {
            get
            {
                return ChanceToFind.ToString() + "%";
            }
        }

        private int scarcityValue;
        public int ScarcityValue
        {
            get
            {
                if (scarcityValue > MaxValue)
                    return MaxValue;
                else if (scarcityValue < MinValue)
                    return MinValue;
                else
                    return scarcityValue;
            }

            set
            {
                if (value > MaxValue)
                    scarcityValue = MaxValue;
                else if (value < MinValue)
                    scarcityValue = MinValue;
                else
                    scarcityValue = value;
            }
        }

        public ScarcityLevel Level
        {
            get
            {
                return GetScarcityLevel(ScarcityValue);
            }
        }

        public Scarcity()
        {
            ScarcityValue = 10000;
        }

        public Scarcity(int findChance)
        {
            ScarcityValue = findChance;
        }

        public bool Find()
        {
            return TryToFind(ScarcityValue);
        }

        public static bool Find(int findChance)
        {
            return TryToFind(findChance);
        }

        public static bool Find(ScarcityLevel findChance)
        {
            return TryToFind((int)findChance);
        }

        private static bool TryToFind(int findChance)
        {
            Random r = new Random();

            if (r.Next(MinValue, MaxValue + 1) <= findChance)
                return true;
            else
                return false;
        }

        public static float GetChanceToFind(int scarceValue)
        {
            if (scarceValue > MaxValue)
                scarceValue = MaxValue;
            else if (scarceValue < MinValue)
                scarceValue = MinValue;

            return (scarceValue / MaxValue) * 100;
        }

        public static ScarcityLevel GetScarcityLevel(int level)
        {
            if (level <= (MaxValue / MaxValue))
                return ScarcityLevel.SuperLegendary;

            else if (level <= (MaxValue / 5000))
                return ScarcityLevel.Legendary;

            else if (level <= (MaxValue / 1000))
                return ScarcityLevel.SuperUnique;

            else if (level <= (MaxValue / 500))
                return ScarcityLevel.VeryUnique;

            else if (level <= (MaxValue / 100))
                return ScarcityLevel.Unique;

            else if (level <= (MaxValue / 50))
                return ScarcityLevel.SuperRare;

            else if (level <= (MaxValue / 20))
                return ScarcityLevel.VeryRare;

            else if (level <= (MaxValue / 10))
                return ScarcityLevel.Rare;

            else if (level <= (MaxValue / 5))
                return ScarcityLevel.Common;

            else if (level <= (MaxValue / 2))
                return ScarcityLevel.VeryCommon;
            else
                return ScarcityLevel.Everywhere;
        }

        public static ScarcityLevel GetRandomScarcityLevel(short startingScarcityLevel = 0)
        {
            if (startingScarcityLevel > MaxStartingLevel)
                startingScarcityLevel = MaxStartingLevel;

            Random r = new Random();
            int roll = r.Next(1, RollMax + 1);

            while (roll == RollMax)
            {
                startingScarcityLevel++;
                roll = r.Next(1, RollMax + 1);
            }

            return (ScarcityLevel)startingScarcityLevel;

            ////List<int> deepList = new List<int>();

            //int deep = 0;
            //int roll = 5;
            //long totalRolls = 0;
            ////levels++;

            ////while (r.Next(1, 6) == 5)
            ////{
            ////    deep++;
            ////}

            ////int exit = levels;

            //while(deep <= startingScarcityLevel)
            //{
            //    deep = 1;
            //    roll = 5;

            //    while (roll == 5)
            //    {
            //        roll = r.Next(1, 6);
            //        deep++;
            //        totalRolls++;
            //    }
            //}

            //++++++++++++++++++++++++++
        }
    }

    
    
}
