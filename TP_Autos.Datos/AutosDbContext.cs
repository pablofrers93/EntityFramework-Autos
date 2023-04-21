using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TP_Autos.Datos.EntityTypeConfiguration;
using TP_Autos.Entidades;

namespace TP_Autos.Datos
{
    public class AutosDbContext : DbContext
    {
        public AutosDbContext()
            : base("name=AutosDbContext")
        {
        }

        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<PaisDeOrigen> PaisesDeOrigen { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<TipoDeVehiculo> TiposDeVehiculos { get; set; }
        public virtual DbSet<Vendedor> Vendedores { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<CategoriaDeVendedores> CategoriasDeVendedores { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AutoEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ClienteEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new LocalidadEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new MarcaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PaisDeOrigenEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new SucursalEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TipoDeVehiculoEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new VendedorEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new VentaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaDeVendedoresEntityTypeConfiguration());
        }
    }
}
