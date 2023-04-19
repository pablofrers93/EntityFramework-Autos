using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class VentaEntityTypeConfiguration:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfiguration()
        {
            ToTable("Ventas");
            HasKey(v => v.VentasId);
            Property(v => v.Patente).IsRequired().HasMaxLength(255);
            Property(v => v.Monto).HasColumnType("money");
        }
    }
}
