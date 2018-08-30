using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Stats
{
    class UnitStats : IUnitStats
    {
        private int _level = 1;

        private int _strength = 10;
        private int _dexterity = 10;
        private int _constitution = 10;
        private int _intelligence = 10;
        private int _wisdom = 10;
        private int _charisma = 10;

        private int _melee;
        private int _ranged;
        private int _magic;

        private int _armorClass;
        private int _block;
        private int _dodge;
        private int _parry;
        private int _willpower;
        private int _immunity;

        public int Power => _strength * _dexterity * _constitution;
        public int Mind => _intelligence * _wisdom * _charisma;
        public int Energy => throw new NotImplementedException();

        public int Strength => (LevelBonus + _strength) - 10 / 2;
        public int Dexterity => (LevelBonus + _dexterity) - 10 / 2;
        public int Constitution => (LevelBonus + _constitution) - 10 / 2;
        public int Intelligence => (LevelBonus + _intelligence) - 10 / 2;
        public int Wisdom => (LevelBonus + _wisdom) - 10 / 2;
        public int Charisma => (LevelBonus + _charisma) - 10 / 2;

        public int PrimaryAbility => Math.Max(Math.Max(Intelligence, Wisdom), Charisma);
        public int LevelBonus => _level / 10 + 1;

        public int Melee => _melee + Strength;
        public int Ranged => _ranged + Dexterity;
        public int Magic => _magic + PrimaryAbility;

        public int ArmorClass => _armorClass;
        public int Block => _block + Strength;
        public int Dodge => _dodge + Dexterity;
        public int Parry => _parry + Dexterity;
        public int Willpower => _willpower + PrimaryAbility;
        public int Immunity => _immunity + Constitution;

        public int Level => _level;
    }
}
