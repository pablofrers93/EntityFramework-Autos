namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendedore
    {
        [Key]
        public int VendedorId { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreyApellido { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string Categoria { get; set; }
    }
}
