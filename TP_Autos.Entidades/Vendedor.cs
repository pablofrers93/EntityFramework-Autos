    using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Vendedor
    {
        public int VendedorId { get; set; }
        public string NombreyApellido { get; set; }
        public string Telefono { get; set; }
        public string Categoria { get; set; }

        public int CategoriaDeVendedoresId { get; set; }

        public virtual CategoriaDeVendedores CategoriaDeVendedores { get; set; }

    }
}
