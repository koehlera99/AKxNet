using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rpg.Data.Core.Models
{
    public partial class Weapons
    {
        [Key]
        public Guid WeaponId { get; set; }
        [Required]
        [StringLength(35)]
        public string WeaponName { get; set; }
        [Required]
        [StringLength(255)]
        public string WeaponDescription { get; set; }
        [Required]
        [StringLength(25)]
        public string WeaponType { get; set; }
        public int WeaponPropertyFlag { get; set; }
        [Required]
        [StringLength(3)]
        public string PrimaryStat { get; set; }
        [StringLength(10)]
        public string WeaponDamageType { get; set; }
        public byte AttackBonus { get; set; }
        public byte DefenseBonus { get; set; }
        public byte ParryChance { get; set; }
        public byte BlockChance { get; set; }
        public byte CritChanceBonus { get; set; }
        public short CritDamageBonus { get; set; }
        public short MinRange { get; set; }
        public short MaxRange { get; set; }
        public byte DamageDie { get; set; }
        public byte NumRolls { get; set; }

        [ForeignKey("WeaponDamageType")]
        [InverseProperty("Weapons")]
        public WeaponDamageTypes WeaponDamageTypeNavigation { get; set; }
        [ForeignKey("WeaponType")]
        [InverseProperty("Weapons")]
        public WeaponTypes WeaponTypeNavigation { get; set; }
    }
}
