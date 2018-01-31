namespace DnD.Core.Domain
{
    public class City : Object
    {
        public int Population { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
