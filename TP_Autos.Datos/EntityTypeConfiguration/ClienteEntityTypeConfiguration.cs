using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Entidades;

namespace TP_Autos.Datos.EntityTypeConfiguration
{
    public class ClienteEntityTypeConfiguration:EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityTypeConfiguration()
        {
            ToTable("Clientes");
            HasKey(c => c.ClienteId);
            Property(c => c.NombreApellido).IsRequired().HasMaxLength(200);
            Property(c => c.Dirección).IsRequired().HasMaxLength(120);
            Property(c => c.Teléfono).IsRequired().HasMaxLength(20);
            Property(c => c.Sexo).IsRequired().HasMaxLength(1);
            Property(c => c.ProvinciaId).IsRequired();
            Property(c => c.LocalidadId).IsRequired();
        }
    }
}
