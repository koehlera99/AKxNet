using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;


namespace TCS.FantasyBattle
{
    class RoomSection
    {
        public readonly Guid ID;
        public const int Size = 5;
        public System.Windows.Point Location { get; set; }

        public bool IsNothing { get; set; } = false;
        public UnitSection SectionUnitIsIn { get; set; }

        public double X { get { return Location.X; } }
        public double Y { get { return Location.Y; } }

        #region Visual Aspects

        public Canvas CanvasMap { get; set; }
        public Rectangle Rect { get; set; }
        public Brush NormalBrush { get; set; }

        private const double strokeThickness = .75;
        
        #endregion

        public RoomSection(System.Windows.Point location)
        {
            ID = Guid.NewGuid();
            Location = location;
        }

        public RoomSection(double x, double y)
        {
            ID = Guid.NewGuid();
            Location = new System.Windows.Point(x, y);
        }
    }
}
