using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class PaisDeOrigenEntityTypeConfiguration:EntityTypeConfiguration<PaisDeOrigen>
    {
        public PaisDeOrigenEntityTypeConfiguration()
        {
            ToTable("PaisesDeOrigen");
            HasKey(p => p.PaisDeOrigenId);
            Property(p => p.NombrePais).IsRequired().HasMaxLength(100);
        }
    }
}
