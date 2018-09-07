namespace RPG.Standard.Units
{
    public sealed class LevelManager
    {
        private const int _baseXp = 100;
        private const int _maxLevel = 100;
        private const float _levelMultiplier = 1.5f;
        private readonly long[] _levels;

        public LevelManager()
        {
            _levels = new long[_maxLevel];
            _levels[0] = _baseXp;

            for (int i = 1; i < _maxLevel; i++)
                _levels[i] = (long)(_levels[i - 1] * _levelMultiplier);
        }

        public long GetNextLevelXP(int currentLevel)
        {
            return _levels[currentLevel];
        }

        public int GetLevel(long xp)
        {
            int lastLevel = 1;

            if (xp > _baseXp)
            {
                foreach (long level in _levels)
                {
                    lastLevel++;

                    if (xp > level && xp < level * _levelMultiplier)
                    {
                        break;
                    }
                }
            }

            return lastLevel;
        }
    }
}
