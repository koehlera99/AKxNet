using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.RPG.Worlds
{
    class Section
    {
        public readonly Guid ID;
        public const int Size = 5;
        public System.Windows.Point Location { get; set; }

        public bool IsNothing { get; set; } = false;
        //public UnitSection SectionUnitIsIn { get; set; }
        public List<ISectionItem> Items { get; set; }

        #region Visual Aspects

        //public Canvas CanvasMap { get; set; }
        //public Rectangle Rect { get; set; }
        //public Brush NormalBrush { get; set; }

        private const double strokeThickness = .75;

        #endregion

        public Section(System.Windows.Point location)
        {
            ID = Guid.NewGuid();
            Location = location;
        }

        public Section(double x, double y)
        {
            ID = Guid.NewGuid();
            Location = new System.Windows.Point(x, y);
        }
    }
}
