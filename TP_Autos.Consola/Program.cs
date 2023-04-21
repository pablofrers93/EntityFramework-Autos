using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
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
            //GetVendedoresWithCategoriaVendedorId();


        }


    /*private static void GetVendedoresWithCategoriaVendedorId()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaCategoriasDeVendedores = db.CategoriasDeVendedores.ToList();

                foreach (var categoria in listaCategoriasDeVendedores)
                {
                    var listaVendedores = db.Vendedores.Where(v => v.Categoria.Contains(categoria.Descripcion)).ToList();

                    if (listaVendedores.Count()>0)
                    {
                        var categoriaDeVendedor = db.CategoriasDeVendedores.SingleOrDefault(c=>c.Descripcion == categoria.Descripcion); 

                        if (categoriaDeVendedor!=null)
                        {
                            foreach (var vendedor in listaVendedores)
                            {
                                vendedor.CategoriaDeVendedoresId = categoriaDeVendedor.CategoriaDeVendedoresId;
                            }
                        }
                    }
                }
                db.SaveChanges();
            }
            
        }
        */
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
