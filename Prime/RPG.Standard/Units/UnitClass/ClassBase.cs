using RPG.Standard.Stats;

namespace RPG.Standard.Units.UnitClass
{
    class ClassBase
    {
        public PrimaryFlag PrimaryStat { get; set; } = PrimaryFlag.Str;
        public PrimaryFlag SecondaryStat { get; set; } = PrimaryFlag.Dex;

        public short HitDice { get; set; }

        public ClassBase() { }
    }
}
