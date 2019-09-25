using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GOK_SERVER.Data.GOK
{
    public partial class GOKContext : DbContext
    {
        public GOKContext()
        {
        }

        public GOKContext(DbContextOptions<GOKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gebruikers> Gebruikers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Gebruikers>(entity =>
            {
                entity.HasKey(e => e.Spelersnummer)
                    .HasName("PK__Gebruike__43D3BD8088663CFE");

                entity.Property(e => e.DailyGiftDatum).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gebruikersnaam)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Wachtwoord)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}