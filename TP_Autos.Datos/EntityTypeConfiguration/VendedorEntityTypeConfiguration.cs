using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class VendedorEntityTypeConfiguration:EntityTypeConfiguration<Vendedor>
    {
        public VendedorEntityTypeConfiguration()
        {
            ToTable("Vendedores");
            HasKey(v => v.VendedorId);
            Property(v => v.NombreyApellido).IsRequired().HasMaxLength(200);
            Property(v => v.Telefono).IsRequired().HasMaxLength(20);
            Property(v => v.Categoria).IsRequired().HasMaxLength(10);
        }
    }
}
