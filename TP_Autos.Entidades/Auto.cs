using System;
using System.Collections.Generic; 

namespace TP_Autos.Entidades
{ 
    public partial class Auto
    {
        public int AutoId { get; set; }

        public int MarcaId { get; set; }
        public string Modelo { get; set; }

        public decimal PrecioFinal { get; set; }

        public int TipoDeVehiculoId { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual TipoDeVehiculo TiposDeVehiculo { get; set; }
    }
}
