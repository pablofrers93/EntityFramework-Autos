using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Autos.Entidades
{
    public class CategoriaDeVendedores
    {
        public int CategoriaDeVendedoresId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Vendedor> Vendedores { get; set; }
    }
}
