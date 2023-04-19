namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaisesDeOrigen")]
    public partial class PaisesDeOrigen
    {
        [Key]
        public int PaisDeOrigenId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePais { get; set; }
    }
}
