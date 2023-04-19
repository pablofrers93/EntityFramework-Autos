using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class CategoriaDeVendedoresEntityTypeConfiguration:EntityTypeConfiguration<CategoriaDeVendedores>
    {
        public CategoriaDeVendedoresEntityTypeConfiguration()
        {
            ToTable("CategoriasDeVendedores");
            HasKey(c => c.CategoriaDeVendedoresId);
            Property(c => c.Descripcion).IsRequired().HasMaxLength(10);
            HasIndex(c => c.Descripcion).IsUnique().HasName("IX_CategoriasDevendedores_Descripcion");
        }
    }
}
