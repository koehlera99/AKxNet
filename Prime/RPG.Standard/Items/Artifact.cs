using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Standard.Items
{
    public class Artifact : Item
    {
        public ArtifactSlots ArtifactSlot { get; set; } = ArtifactSlots.None;
        public Artifact()
        {
            //ItemType = ItemTypes.Artifact;
            Name = "Artifact";
        }
    }

    
}
