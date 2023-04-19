using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class LocalidadEntityTypeConfiguration:EntityTypeConfiguration<Localidad>
    {
        public LocalidadEntityTypeConfiguration()
        {
            ToTable("Localidades");
            HasKey(l => l.LocalidadId);
            Property(l => l.Nombre).IsRequired().HasMaxLength(50);

        }
    }
}
