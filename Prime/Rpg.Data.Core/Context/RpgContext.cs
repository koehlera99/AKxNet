using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rpg.Data.Core.Models
{
    public partial class RpgContext : DbContext
    {
        public RpgContext()
        {
        }

        public RpgContext(DbContextOptions<RpgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armies> Armies { get; set; }
        public virtual DbSet<Armor> Armor { get; set; }
        public virtual DbSet<ArmorProperties> ArmorProperties { get; set; }
        public virtual DbSet<ArmorSlot> ArmorSlot { get; set; }
        public virtual DbSet<ArmorType> ArmorType { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Names> Names { get; set; }
        public virtual DbSet<Platoons> Platoons { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<RaceClassBonus> RaceClassBonus { get; set; }
        public virtual DbSet<Squads> Squads { get; set; }
        public virtual DbSet<UnitArmor> UnitArmor { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<UnitStats> UnitStats { get; set; }
        public virtual DbSet<UnitWeapons> UnitWeapons { get; set; }
        public virtual DbSet<WeaponDamageTypes> WeaponDamageTypes { get; set; }
        public virtual DbSet<WeaponProperties> WeaponProperties { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }
        public virtual DbSet<WeaponTypes> WeaponTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:akxnet.database.windows.net,1433;Initial Catalog=Rpg;Persist Security Info=False;User ID='aaron';Password='#Arcade1';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armies>(entity =>
            {
                entity.Property(e => e.ArmyId).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Armies)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_Armies_Players");
            });

            modelBuilder.Entity<Armor>(entity =>
            {
                entity.Property(e => e.ArmorId).ValueGeneratedNever();

                entity.Property(e => e.ArmorDescription).IsUnicode(false);

                entity.Property(e => e.ArmorName).IsUnicode(false);

                entity.Property(e => e.ArmorSlot).IsUnicode(false);

                entity.Property(e => e.ArmorType).IsUnicode(false);

                entity.HasOne(d => d.ArmorNavigation)
                    .WithOne(p => p.InverseArmorNavigation)
                    .HasForeignKey<Armor>(d => d.ArmorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Armor_Armor");

                entity.HasOne(d => d.ArmorSlotNavigation)
                    .WithMany(p => p.Armor)
                    .HasForeignKey(d => d.ArmorSlot)
                    .HasConstraintName("FK_Armor_ArmorSlot");

                entity.HasOne(d => d.ArmorTypeNavigation)
                    .WithMany(p => p.Armor)
                    .HasForeignKey(d => d.ArmorType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Armor_ArmorType");
            });

            modelBuilder.Entity<ArmorProperties>(entity =>
            {
                entity.Property(e => e.PropertyName)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PropertyDescription).IsUnicode(false);
            });

            modelBuilder.Entity<ArmorSlot>(entity =>
            {
                entity.Property(e => e.ArmorSlot1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SlotDescription).IsUnicode(false);
            });

            modelBuilder.Entity<ArmorType>(entity =>
            {
                entity.Property(e => e.ArmorType1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Names>(entity =>
            {
                entity.HasKey(e => new { e.NameType, e.Race, e.Random });

                entity.Property(e => e.NameType).IsUnicode(false);

                entity.Property(e => e.Race).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Platoons>(entity =>
            {
                entity.Property(e => e.PlatoonId).ValueGeneratedNever();

                entity.HasOne(d => d.Army)
                    .WithMany(p => p.Platoons)
                    .HasForeignKey(d => d.ArmyId)
                    .HasConstraintName("FK_Platoons_Armies");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.PlayerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<RaceClassBonus>(entity =>
            {
                entity.HasKey(e => new { e.RaceId, e.ClassId });
            });

            modelBuilder.Entity<Squads>(entity =>
            {
                entity.Property(e => e.SquadId).ValueGeneratedNever();

                entity.HasOne(d => d.Platoon)
                    .WithMany(p => p.Squads)
                    .HasForeignKey(d => d.PlatoonId)
                    .HasConstraintName("FK_Squads_Platoons");
            });

            modelBuilder.Entity<UnitArmor>(entity =>
            {
                entity.HasKey(e => new { e.UnitId, e.ArmorId });
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasIndex(e => e.BackgroundId);

                entity.HasIndex(e => e.ClassId);

                entity.HasIndex(e => e.RaceId);

                entity.Property(e => e.UnitId).ValueGeneratedNever();

                entity.HasOne(d => d.Squad)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.SquadId)
                    .HasConstraintName("FK_Units_Squads");
            });

            modelBuilder.Entity<UnitStats>(entity =>
            {
                entity.Property(e => e.UnitId).ValueGeneratedNever();

                entity.HasOne(d => d.Unit)
                    .WithOne(p => p.UnitStats)
                    .HasForeignKey<UnitStats>(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitStats_Units");
            });

            modelBuilder.Entity<UnitWeapons>(entity =>
            {
                entity.HasKey(e => new { e.UnitId, e.WeaponId });
            });

            modelBuilder.Entity<WeaponDamageTypes>(entity =>
            {
                entity.Property(e => e.DamageTypeName)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DamageTypeDescription).IsUnicode(false);
            });

            modelBuilder.Entity<WeaponProperties>(entity =>
            {
                entity.Property(e => e.PropertyName)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PropertyDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.Property(e => e.WeaponId).ValueGeneratedNever();

                entity.Property(e => e.PrimaryStat).IsUnicode(false);

                entity.Property(e => e.WeaponDamageType).IsUnicode(false);

                entity.Property(e => e.WeaponDescription).IsUnicode(false);

                entity.Property(e => e.WeaponName).IsUnicode(false);

                entity.Property(e => e.WeaponType).IsUnicode(false);

                entity.HasOne(d => d.WeaponDamageTypeNavigation)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponDamageType)
                    .HasConstraintName("FK_Weapons_WeaponDamageTypes");

                entity.HasOne(d => d.WeaponTypeNavigation)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Weapons_WeaponTypes");
            });

            modelBuilder.Entity<WeaponTypes>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeDescription).IsUnicode(false);
            });
        }
    }
}
