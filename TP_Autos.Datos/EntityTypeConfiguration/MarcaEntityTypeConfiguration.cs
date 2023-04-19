using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class MarcaEntityTypeConfiguration:EntityTypeConfiguration<Marca>
    {
        public MarcaEntityTypeConfiguration()
        {
            ToTable("Marcas");
            HasKey(m => m.MarcaId);
            Property(m => m.NombreMarca).IsRequired().HasMaxLength(50);

        }
    }
}
