using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Background
    {
        public int BackgroundId { get; set; }
        public string BackgroundName { get; set; }
    }
}
