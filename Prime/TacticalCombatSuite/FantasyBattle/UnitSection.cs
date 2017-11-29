using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TCS.FantasyBattle
{
    /// <summary>
    /// Kind of a gate way between the Unit and the Section of the room its in
    /// </summary>
    class UnitSection
    {
        public RoomSection CurrentSection { get; set; }
        public RPG.Units.Unit UnitInThisSection { get; set; }
        public readonly Guid ID;

        public UnitSection()
        {
            ID = Guid.NewGuid();
        }

        public UnitSection(RoomSection startingSection)
        {
            ID = Guid.NewGuid();
            CurrentSection = startingSection;
            startingSection.SectionUnitIsIn = this;
        }

        public bool MoveUnit(RoomSection sectionToMoveTo)
        {
            CurrentSection.Rect.Fill = CurrentSection.NormalBrush;
            CurrentSection.SectionUnitIsIn = null;

            CurrentSection = sectionToMoveTo;
            sectionToMoveTo.SectionUnitIsIn = this;

            CurrentSection.Rect.Fill = Brushes.Red;

            return true;
        }



    }
}
