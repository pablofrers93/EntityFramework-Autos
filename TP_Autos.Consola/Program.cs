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
            //AutoIdFieldRandomValuesVentasTable();
            //UpdateValorVentaInVentasTable();

        }

        private static void UpdateValorVentaInVentasTable()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaAutos = db.Autos.ToList();

                foreach (var auto in listaAutos)
                {
                    var listaVentas = db.Ventas.Where(v=>v.AutoId == auto.AutoId).ToList();

                    if (listaVentas.Count()>0)
                    {
                        foreach (var venta in listaVentas)
                        {
                            venta.Monto = auto.PrecioFinal;
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        private static void AutoIdFieldRandomValuesVentasTable()
        {
            
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaVentas = db.Ventas.ToList();
                var listaAutosId = db.Autos.Select(a => a.AutoId).ToList();
                Random value = new Random();

                foreach (var venta in listaVentas)
                {
                    int randIndex = value.Next(listaAutosId.Count());
                    int random = listaAutosId[randIndex];
                    var auto = db.Autos.SingleOrDefault(a => a.AutoId == random) ;
                    if (auto != null)
                    {
                        venta.AutoId = auto.AutoId;
                        listaAutosId.Remove(random);
                    }
                }
                db.SaveChanges();   
            }
            Console.ReadLine();
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
