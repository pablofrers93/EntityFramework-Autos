using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TP_Autos.Datos
{
    public partial class AutosDbContext : DbContext
    {
        public AutosDbContext()
            : base("name=AutosDbContext")
        {
        }

        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Localidade> Localidades { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<PaisesDeOrigen> PaisesDeOrigens { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<TiposDeVehiculo> TiposDeVehiculos { get; set; }
        public virtual DbSet<Vendedore> Vendedores { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.NombreMarca)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Autos)
                .WithRequired(e => e.Marca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposDeVehiculo>()
                .HasMany(e => e.Autos)
                .WithRequired(e => e.TiposDeVehiculo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.Monto)
                .HasPrecision(19, 4);
        }
    }
}
