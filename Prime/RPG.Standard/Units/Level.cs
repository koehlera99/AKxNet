namespace RPG.Standard.Units
{
    public class Level
    {
        public static LevelManager Manager { get; } = new LevelManager();
        public long XP { get; private set; }
        public int Value { get; private set; }
        public int Bonus => (Value / 10) + 1;

        public Level(long xp)
        {
            XP = xp;
            Value = Manager.GetLevel(xp);
        }

        public void Set(long xp)
        {
            XP = xp;
            Value = Manager.GetLevel(xp);
        }

        public void Adjust(long xp)
        {
            XP += xp;
            Value = Manager.GetLevel(xp);
        }
    }
}
