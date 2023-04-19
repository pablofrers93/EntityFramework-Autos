using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class ProvinciaEntityTypeConfiguration:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaEntityTypeConfiguration()
        {
            ToTable("Provincias");
            HasKey(p => p.ProvinciaId);
            Property(p=>p.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}
