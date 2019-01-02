using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Models
{
    public partial class RpgNamesContext : DbContext
    {
        public RpgNamesContext()
        {
        }

        public RpgNamesContext(DbContextOptions<RpgNamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armies> Armies { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Names> Names { get; set; }
        public virtual DbSet<Platoons> Platoons { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Squads> Squads { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Rpg;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armies>(entity =>
            {
                entity.HasKey(e => e.ArmyId);

                entity.HasIndex(e => e.PlayerId);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Armies)
                    .HasForeignKey(d => d.PlayerId);
            });

            modelBuilder.Entity<Names>(entity =>
            {
                entity.HasKey(e => new { e.NameType, e.Race, e.Random });

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

               
            });

            modelBuilder.Entity<Platoons>(entity =>
            {
                entity.HasKey(e => e.PlatoonId);

                entity.HasIndex(e => e.ArmyId);

                entity.HasOne(d => d.Army)
                    .WithMany(p => p.Platoons)
                    .HasForeignKey(d => d.ArmyId);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId);
            });

            modelBuilder.Entity<Squads>(entity =>
            {
                entity.HasKey(e => e.SquadId);

                entity.HasIndex(e => e.PlatoonId);

                entity.HasOne(d => d.Platoon)
                    .WithMany(p => p.Squads)
                    .HasForeignKey(d => d.PlatoonId);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.HasIndex(e => e.BackgroundId);

                entity.HasIndex(e => e.ClassId);

                entity.HasIndex(e => e.RaceId);

                entity.HasIndex(e => e.SquadId);

                entity.HasOne(d => d.Background)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.BackgroundId);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.ClassId);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.RaceId);

                entity.HasOne(d => d.Squad)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.SquadId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
