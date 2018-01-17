using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Data.Entity
{
    class GameEntity
    {

    }

    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [DisplayName("Game")]
        public string GameName { get; set; }

        public virtual List<Player> Players { get; set; }
    }

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [DisplayName("Player")]
        public string Playername { get; set; }
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual List<Campaign> Campaigns { get; set; }
    }

    public class Campaign
    {
        [Key]
        public int CampaignId { get; set; }
        [DisplayName("Campaign")]
        public string CampaignTitle { get; set; }
        public string Content { get; set; }

        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual List<Unit> Units { get; set; }
        public virtual List<Mission> Missions { get; set; }
    }

    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        [DisplayName("Unit Name")]
        public string UnitName { get; set; }

        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        public int? SquadId { get; set; }
        public virtual Squad Squad { get; set; }

        public int ClassId { get; set; }
        public virtual UnitClass UnitClass { get; set; }

        public List<Equipment> Equipment { get; set; }
    }

    public class UnitClass
    {
        [Key]
        public int ClassId { get; set; }
        [DisplayName("Class")]
        public string ClassName { get; set; }

        public virtual List<Unit> Units { get; set; }
    }

    public class Squad
    {
        [Key]
        public int SquadId { get; set; }
        [DisplayName("Squad")]
        public string SquadName { get; set; }

        public virtual List<Unit> Units { get; set; }
    }

    public class Mission
    {
        [Key]
        public int MissionId { get; set; }
        [DisplayName("Mission")]
        public string MissionName { get; set; }
        [DisplayName("Parameters")]
        public string MissionParameters { get; set; }

        public int? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
    }

    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        [DisplayName("Item Name")]
        public string EquipmentName { get; set; }
        [DisplayName("Description")]
        public string EquipmentDescription { get; set; }

        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitClass> UnitClasses { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
    }
}
