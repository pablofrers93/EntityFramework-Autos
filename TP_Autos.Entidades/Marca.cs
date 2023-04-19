using System;
using System.Collections.Generic;

namespace TP_Autos.Entidades
{
    public partial class Marca
    {
        public Marca()
        {
            Autos = new HashSet<Auto>();
        }

        public int MarcaId { get; set; }
        public string NombreMarca { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
