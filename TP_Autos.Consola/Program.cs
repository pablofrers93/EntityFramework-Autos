using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TP_Autos.Datos;
using TP_Autos.Entidades;

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
            //AddTwoRegistersToSucursalesTable();
            //AddSucursalIdToVentasTable();
            //AddPaisDeOrigenIdToAutosTable();
            //UpdateLocalidadIdAndProvinciaIdInTableClientes();

        }

        /*private static void UpdateLocalidadIdAndProvinciaIdInTableClientes()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaClientes = db.Clientes.ToList();

                foreach (var cliente in listaClientes)
                {
                    var localidad = db.Localidades.SingleOrDefault(l => l.Nombre == cliente.Localidad);
                    if (localidad != null)
                    {
                        cliente.LocalidadId = localidad.LocalidadId;
                        cliente.ProvinciaId = localidad.ProvinciaId;
                    }
                }
                db.SaveChanges();
            }
        }*/
        private static void AddPaisDeOrigenIdToAutosTable()
        {
             using (AutosDbContext db = new AutosDbContext())
            {
                var listaAutos = db.Autos.ToList();
                var listaPaisesDeOrigenId = db.PaisesDeOrigen.Select(p => p.PaisDeOrigenId).ToList();
                Random value = new Random();

                foreach (var auto in listaAutos)
                {
                    int randIndex = value.Next(listaPaisesDeOrigenId.Count());
                    int random = listaPaisesDeOrigenId[randIndex];
                    var paisDeOrigen = db.PaisesDeOrigen.SingleOrDefault(a => a.PaisDeOrigenId == random);
                    if (paisDeOrigen != null)
                    {
                        auto.PaisDeOrigenId = paisDeOrigen.PaisDeOrigenId;
                    }
                }
                db.SaveChanges();
            }
        }

        private static void AddSucursalIdToVentasTable()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaVentas = db.Ventas.ToList();
                var listaSucursalesId = db.Sucursales.Select(s => s.SucursalId).ToList();
                Random value = new Random();

                foreach (var venta in listaVentas)
                {
                    int randIndex = value.Next(listaSucursalesId.Count());
                    int random = listaSucursalesId[randIndex];
                    var sucursal = db.Sucursales.SingleOrDefault(s => s.SucursalId == random);
                    if (sucursal != null)
                    {
                        venta.SucursalId = sucursal.SucursalId;
                    }
                }
                db.SaveChanges();
            }
        }

        private static void AddTwoRegistersToSucursalesTable()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var sucursal1 = new Sucursal();
                sucursal1.NombreSucursal = "Ricciardi Automotores";
                sucursal1.Calle = "Buenos Aires";
                sucursal1.Altura = "595";
                sucursal1.LocalidadId = 1;
                sucursal1.ProvinciaId = 1;
                sucursal1.CodigoPostal = "7240";

                var sucursal2 = new Sucursal();
                sucursal2.NombreSucursal = "Volkswagen Automotores";
                sucursal2.Calle = "Castelli";
                sucursal2.Altura = "1230";
                sucursal2.LocalidadId = 1;
                sucursal2.ProvinciaId = 1;
                sucursal2.CodigoPostal = "7240";

                db.Sucursales.Add(sucursal1);
                db.Sucursales.Add(sucursal2);

                db.SaveChanges();
            }
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
