namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Venta
    {
        [Key]
        public int VentasId { get; set; }

        [Required]
        [StringLength(255)]
        public string Patente { get; set; }

        public int ClienteId { get; set; }

        public int VendedorId { get; set; }

        public DateTime FechaOperación { get; set; }

        [Column(TypeName = "money")]
        public decimal Monto { get; set; }

        public int? AutoId { get; set; }

        public int? SucursalId { get; set; }
    }
}
