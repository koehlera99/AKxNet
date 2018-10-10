using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class UnitWeapons
    {
        public Guid UnitId { get; set; }
        public Guid WeaponId { get; set; }
    }
}
