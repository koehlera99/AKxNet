using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core;

namespace Web.Domain
{
    public class Campaign : DndObject
    {
        public List<ILocation> Locations { get; set; }
        public List<City> Cities { get; set; }

        private List<ILocation> Locations2 { get; set; }
    }
}
