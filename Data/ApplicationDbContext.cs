
using Taller.Entidades;
using Taller.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Taller.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            //modelBuilder.Entity<PeliculasGeneros>()
            //    .HasKey(x => new { x.GeneroId, x.PeliculaId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.DescripciónTipo).IsUnique();
            modelBuilder.Entity<Marca>().HasIndex(x => x.NombreMarca).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.DescTipoDocumento).IsUnique();

         }



        public DbSet<Detalle> Detalles { get; set; }

        public DbSet<Historial> Historiales{ get; set; }

        public DbSet<ImagenVehiculo> ImagenVehiculos { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Procedimiento> Procedimientos { get; set; }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<IdentityModels> Models  { get; set; }  

    }
}
