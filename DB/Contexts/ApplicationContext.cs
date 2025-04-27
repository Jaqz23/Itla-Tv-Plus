using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Serie>().HasKey(s => s.Id);
            modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            modelBuilder.Entity<Productora>().HasKey(p => p.Id);
            #endregion

            #region Relationships

            // Relación Productora (1:N) Serie
            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(s => s.ProductoraId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Genero (Primario) (1:N) Serie 
            modelBuilder.Entity<Genero>()
                .HasMany<Serie>(g => g.GeneroPrimario)
                .WithOne(s => s.GeneroPrimario)
                .HasForeignKey(s => s.GeneroPrimarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Genero (Secundario) (1:N) Serie 
            modelBuilder.Entity<Genero>()
                .HasMany<Serie>(g => g.GeneroSecundario)
                .WithOne(s => s.GeneroSecundario)
                .HasForeignKey(s => s.GeneroSecundarioId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Property Configurations

            #region Series
            modelBuilder.Entity<Serie>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Serie>()
                .Property(s => s.ImagePath)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(s => s.VideoLink)
                .IsRequired();
            #endregion

            #region Generos
            modelBuilder.Entity<Genero>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region Productoras
            modelBuilder.Entity<Productora>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
