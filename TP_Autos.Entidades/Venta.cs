using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Venta 
    {
        public int VentasId { get; set; }
        public string Patente { get; set; }

        public int ClienteId { get; set; }

        public int VendedorId { get; set; }

        public DateTime FechaOperación { get; set; }
        public decimal Monto { get; set; }

        public int? AutoId { get; set; }

        public int SucursalId { get; set; }
        public decimal Comision { get; set; }

        public virtual Sucursal Sucursal { get; set; }
    }
}
