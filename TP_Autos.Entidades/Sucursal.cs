using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Sucursal
    {
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public string CodigoPostal { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }

    }
}
