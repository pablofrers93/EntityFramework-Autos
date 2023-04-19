using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class SucursalEntityTypeConfiguration:EntityTypeConfiguration<Sucursal>
    {
        public SucursalEntityTypeConfiguration()
        {
            ToTable("Sucursales");
            HasKey(s => s.SucursalId);
            Property(s => s.NombreSucursal).IsRequired().HasMaxLength(50);
            Property(s => s.Calle).HasMaxLength(100);
            Property(s => s.Altura).HasMaxLength(10);
            Property(s => s.CodigoPostal).HasMaxLength(10);
        }
    }
}
