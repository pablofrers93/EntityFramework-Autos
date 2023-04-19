using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class TipoDeVehiculoEntityTypeConfiguration:EntityTypeConfiguration<TipoDeVehiculo>
    {
        public TipoDeVehiculoEntityTypeConfiguration()
        {
            ToTable("TiposDeVehiculos");
            HasKey(t => t.TipoDeVehiculoId);
            Property(t => t.Descripcion).IsRequired().HasMaxLength(50);
        }
    }
}
