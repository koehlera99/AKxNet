using Core.Models.RPG;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class RpgContext : DbContext
    {
        public RpgContext(DbContextOptions<RpgContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
