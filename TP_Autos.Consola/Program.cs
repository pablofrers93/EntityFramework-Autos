using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
            //ListAutosbyMarca();
            //InformarVentasPorSucursal();
            //Get3HighPricedCarsByCountry();
            //ListComissionsByVendedor();
        }

        private static void ListComissionsByVendedor()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaVendedores = db.Vendedores.ToList();
                Console.WriteLine("++++++++++++++++++++ COMISIONES POR VENTA +++++++++++++++++++++");
                foreach (var vendedor in listaVendedores)
                {
                    var listaVentas = db.Ventas.Where(v=>v.VendedorId==vendedor.VendedorId);
                    var comisionTotal = 0m;
                    if (listaVentas!=null)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var venta in listaVentas)
                        {                            
                            comisionTotal += venta.Comision;
                            var auto = db.Autos.Where(a => a.AutoId == venta.AutoId);
                            sb.AppendLine($"VENTA: {venta.VentasId}, " +
                                                 $"{auto.SingleOrDefault().Marca.NombreMarca}," +
                                                 $"{auto.SingleOrDefault().Modelo}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine($"VENDEDOR: {vendedor.NombreyApellido}, CANTIDAD VENTAS: {listaVentas.Count()}, COMISION TOTAL: {comisionTotal}");
                        Console.WriteLine(sb.ToString());
                    }
               
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        private static void Get3HighPricedCarsByCountry()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaPaises = db.PaisesDeOrigen.ToList();
                Console.WriteLine("+++++++++++++++++ Lista de Paises ++++++++++++++++++");

                foreach (var pais in listaPaises)
                {
                    Console.WriteLine(pais.NombrePais);
                }
                Console.WriteLine("");
                Console.WriteLine("Escriba el nombre del país para saber los 3 autos más caros:");

                var paisElegido = Console.ReadLine();
                var paisInDb = db.PaisesDeOrigen.SingleOrDefault(p => p.NombrePais == paisElegido);

                Console.WriteLine("");
                Console.WriteLine($"Estos son los 3 autos más caros del pais {paisElegido}: ");

                var listaAutos = db.Autos.OrderByDescending(a => a.PrecioFinal).Where(a => a.PaisDeOrigenId == paisInDb.PaisDeOrigenId).ToList();
                for(int i=0; i<3; i++)
                {
                    Console.WriteLine($"{listaAutos[i].Marca.NombreMarca}, {listaAutos[i].Modelo}, {listaAutos[i].PrecioFinal}");
                }
            }
            Console.ReadLine();
        }

        private static void InformarVentasPorSucursal()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaSucursales = db.Sucursales.ToList();

                foreach (var sucursal in listaSucursales)
                {
                    var listaVentas = db.Ventas.Where(v => v.SucursalId == sucursal.SucursalId).ToList();

                    if (listaVentas.Count() > 0)
                    {
                        Console.WriteLine($"Sucursal: {sucursal.NombreSucursal}");
                        Console.WriteLine($"Cantidad Vendida: {listaVentas.Count()}");
                        var montoTotal = 0m;
                        foreach (var venta in listaVentas)
                        {
                            montoTotal += venta.Monto;
                        }
                        Console.WriteLine($"Total recaudado por ventas: {montoTotal}");
                        Console.WriteLine("");

                    }
                }
            }
            Console.ReadLine();
        }

        private static void ListAutosbyMarca()
        {
            using (AutosDbContext db = new AutosDbContext())
            {
                var listaAutos = db.Autos.ToList();
                Console.WriteLine("***************MARCAS DE AUTOS DISPONIBLES:***************");

                foreach (var auto in listaAutos)
                {
                    Console.WriteLine(auto.Marca.NombreMarca);
                }
                Console.WriteLine("***************MARCAS DE AUTOS DISPONIBLES:***************");
                Console.WriteLine("Escriba la marca a listar: ");
                var marca = Console.ReadLine();
                Console.WriteLine("");

                var listaAutosPorMarca = db.Autos.Where(p => p.Marca.NombreMarca == marca).ToList();
                
                foreach (var auto in listaAutosPorMarca)
                {
                    Console.WriteLine($"{auto.Marca.NombreMarca}, {auto.Modelo}, {auto.PrecioFinal}");
                }

            }
            Console.ReadLine();
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
