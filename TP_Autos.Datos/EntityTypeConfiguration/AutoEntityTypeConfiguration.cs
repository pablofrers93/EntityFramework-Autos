using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class AutoEntityTypeConfiguration:EntityTypeConfiguration<Auto>
    {
        public AutoEntityTypeConfiguration()
        {
            ToTable("Autos");
            HasKey(a => a.AutoId);
            Property(a => a.Modelo).IsRequired().HasMaxLength(20);
            Property(a => a.Modelo).IsUnicode(false);
            Property(a => a.PaisDeOrigenId).IsRequired();
        }
    }
}
