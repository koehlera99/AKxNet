using System.Collections.Generic;


namespace DnD.Core.Domain
{
    public class Campaign : Object
    {
        public List<ILocation> Locations { get; set; }
        public List<City> Cities { get; set; }

        private List<ILocation> Locations2 { get; set; }
    }
}
