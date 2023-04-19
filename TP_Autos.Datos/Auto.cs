namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autos")]
    public partial class Auto
    {
        public int AutoId { get; set; }

        public int MarcaId { get; set; }

        [Required]
        [StringLength(20)]
        public string Modelo { get; set; }

        public decimal PrecioFinal { get; set; }

        public int TipoDeVehiculoId { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual TiposDeVehiculo TiposDeVehiculo { get; set; }
    }
}
