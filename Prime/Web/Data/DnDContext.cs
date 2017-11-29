using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.Entity;
using Web.Domain;

namespace DnDWebCore.Data
{
    public class DnDContext : DbContext
    {
        //public DnDContext(DbContextOptions<DnDContext> options) : base(options)
        //{
            
        //}

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Npc> Npcs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>().ToTable("Campaign");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Furniture>().ToTable("Furniture");
        }
    }
}
