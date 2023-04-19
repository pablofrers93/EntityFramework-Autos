namespace TP_Autos.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sucursale
    {
        [Key]
        public int SucursalId { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreSucursal { get; set; }

        [StringLength(100)]
        public string Calle { get; set; }

        [StringLength(10)]
        public string Altura { get; set; }

        public int LocalidadId { get; set; }

        public int ProvinciaId { get; set; }

        [StringLength(10)]
        public string CodigoPostal { get; set; }
    }
}
