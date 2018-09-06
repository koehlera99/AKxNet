using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Game
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Unit> Units { get; set; }
        
        
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public List<Army> Armies { get; set; }
    }


    public class Army
    {
        public int ArmyId { get; set; }
        public string ArmyName { get; set; }

        [Display(Name = "Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public List<Platoon> Platoons { get; set; }
    }

    public class Platoon
    {
        public int PlatoonId { get; set; }
        public string PlatoonName { get; set; }

        [Display(Name = "Army")]
        public int ArmyId { get; set; }
        public Army Army { get; set; }

        public List<Squad> Squads { get; set; }
    }

    public class Squad
    {
        public int SquadId { get; set; }
        public string SquadName { get; set; }

        [Display(Name = "Platoon")]
        public int PlatoonId { get; set; }
        public Platoon Platoon { get; set; }

        public List<Unit> Units { get; set; }
    }

    public class Unit
    {
        public int UnitId { get; set; }

        [Display(Name = "Name")]
        public string UnitName { get; set; }

        public Class Class { get; set; }
        public Race Race { get; set; }
        public Background Background { get; set; }

        [Display(Name = "Squad Name")]
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    public class Race
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
    }

    public class Background
    {
        public int BackgroundId { get; set; }
        public string BackgroundName { get; set; }
    }
}
