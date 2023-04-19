using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Datos;

namespace TP_Autos.Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProbarListadoAEleccion();

            

        }

        private static void ProbarListadoAEleccion()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaAutos = db.Autos.ToList();

                foreach (var auto in listaAutos)
                {
                    Console.WriteLine($"{auto.Marca.NombreMarca}, {auto.TiposDeVehiculo.Descripcion}, {auto.PrecioFinal}");
                }
                Console.ReadLine();
            }
        }
    }
}
