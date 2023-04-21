using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreApellido { get; set; }
        public string Dirección { get; set; }
        public string Teléfono { get; set; }
        public string Sexo { get; set; }
        public int ProvinciaId { get; set; }
        public int LocalidadId { get; set; }

        public virtual Localidad Localidad { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
