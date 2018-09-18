using Microsoft.EntityFrameworkCore;
using RPG.Web.Models.Unit;

namespace RPG.Web.Data
{
    public class UnitContext : DbContext
    {
        public UnitContext(DbContextOptions<UnitContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
