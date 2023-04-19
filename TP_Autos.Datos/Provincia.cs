namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Provincia
    {
        public int ProvinciaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
