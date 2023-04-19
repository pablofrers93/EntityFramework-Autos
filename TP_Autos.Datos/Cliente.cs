namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreApellido { get; set; }

        [Required]
        [StringLength(120)]
        public string Dirección { get; set; }

        [Required]
        [StringLength(100)]
        public string Localidad { get; set; }

        [Required]
        [StringLength(20)]
        public string Teléfono { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        public int? ProvinciaId { get; set; }

        public int? LocalidadId { get; set; }
    }
}
