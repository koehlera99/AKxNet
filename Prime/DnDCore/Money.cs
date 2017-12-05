namespace DnD.Core
{
    public class Money
    {
        public int Platinum { get; set; }
        public int Gold { get; set; }
        public int Electrum { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        public override string ToString()
        {
            return $"Platinum: {Platinum}; Gold: {Gold}; Electrum: {Electrum}; Silver: {Silver}; Copper: {Copper}";
        }
    }
}
