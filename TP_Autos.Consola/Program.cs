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
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaAutos = db.Autos.ToList();

                foreach (var auto in listaAutos)
                {
                    Console.WriteLine($"{auto.Marca.m}, {auto.TiposDeVehiculo.Descripcion}, {auto.PrecioFinal}");
                }
                Console.ReadLine();
            }

        }
    }
}
