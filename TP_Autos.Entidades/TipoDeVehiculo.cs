using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class TipoDeVehiculo
    {
        public TipoDeVehiculo()
        {
            Autos = new HashSet<Auto>();
        }
        public int TipoDeVehiculoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Auto> Autos { get; set; }
    }
}
