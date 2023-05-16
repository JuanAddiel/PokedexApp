using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PokemonContext: DbContext
    {
        public PokemonContext (DbContextOptions<PokemonContext> options) : base(options)
        {
        }
        public DbSet<Region> Region { get; set; }
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Region>()
                .ToTable("Region");
            modelBuilder.Entity<Tipos>()
                .ToTable("Tipos");
            modelBuilder.Entity<Pokemon>()
                .ToTable("Pokemon");
            #endregion

            #region primaryKey
            modelBuilder.Entity<Region>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Tipos>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Pokemon>()
                .HasKey(p => p.Id);
            #endregion

            #region relations
            modelBuilder.Entity<Region>()
                .HasMany(p => p.Pokemon)
                .WithOne(c => c.Region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tipos>()
                .HasMany(p => p.Pokemon)
                .WithOne(c => c.Tipos)
                .HasForeignKey(p => p.TipoId)
                .OnDelete(DeleteBehavior.Cascade);

            //Cascade significa que si
            //borro una categoria se
            //borran todos los productos de la categoria

            #endregion

            #region "Property Configurations"
            #region Tipos
            modelBuilder.Entity<Tipos>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100); ;
            #endregion
            #region Region
            modelBuilder.Entity<Region>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            #endregion
            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Pokemon>()
                .Property(p => p.ImgUrl)
                .IsRequired();
            #endregion
            #endregion
        }

    }
}
