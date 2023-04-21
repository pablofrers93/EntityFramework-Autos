using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Localidad
    {
        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
