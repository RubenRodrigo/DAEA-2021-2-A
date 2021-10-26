using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Origen de datos
            NorthwndDataContext context = new NorthwndDataContext();


            // Creación de consulta
            // Imprimir un listado de la tabla productos
            //var query = from p in context.Products
            //            select p;
            //foreach (var prod in query)
            //{
            //    Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            //}
            //Console.ReadKey();


            //  Listar el ID y nombre de los productos cuya categoría es “Beverages”
            //var query = from p in context.Products
            //            where p.Categories.CategoryName == "Beverages"
            //            select p;
            //foreach (var prod in query)
            //{
            //    Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            //}
            //Console.ReadKey();


            // Listar el ID, el precio y nombre de los productos cuyo precio es menor a 20
            //var query = from p in context.Products
            //            where p.UnitPrice < 20
            //            select p;
            //foreach (var prod in query)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);
            //}
            //Console.ReadKey();


            // *
            // *
            // i.	Listar ID, nombre productos cuyo nombre incluye la palabra “Queso”
            //var query1 = from p in context.Products
            //            where p.ProductName.Contains("Queso")
            //            select p;
            //foreach (var prod in query1)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);                

            //}

            // ii.  Listar ID, nombre, presentación (QuantityPerUnit) productos cuya presentación sea paquetes(pkg o pkgs)       
            //var query2 = from p in context.Products
            //            where p.QuantityPerUnit.Contains("pkg") || p.QuantityPerUnit.Contains("pkgs")
            //            select p;
            //foreach (var prod in query2)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} \t QuantityPerUnit={2} \t Name={3}", prod.ProductID, prod.UnitPrice, prod.QuantityPerUnit, prod.ProductName);

            //}

            // iii. Listar nombre, precio de productos que empiezan con la letra A
            //var query3 = from p in context.Products
            //             where p.ProductName.StartsWith("A")
            //             select p;
            //foreach (var prod in query3)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);
            //}

            // iv.  Listar ID, nombre de productos sin stock
            //var query4 = from p in context.Products
            //             where p.UnitsInStock == 0
            //             select p;
            //foreach (var prod in query4)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} \t Name={2} \t Stock={3}", prod.ProductID, prod.UnitPrice, prod.ProductName, prod.UnitsInStock);
            //}

            // v.   Listar ID, nombre de productos descontinuados
            //var query5 = from p in context.Products
            //             where p.Discontinued
            //             select p;
            //foreach (var prod in query5)
            //{
            //    Console.WriteLine("ID={0} \t Price={1} \t Name={2} \t Descontinued={3}", prod.ProductID, prod.UnitPrice, prod.ProductName, prod.Discontinued);
            //}

            // *
            // *

            //Products p = new Products();
            //p.ProductName = "Peruvian Coffe";
            //p.SupplierID = 20;
            //p.CategoryID = 1;
            //p.QuantityPerUnit = "10 pkgs";
            //p.UnitPrice = 25;

            //// Ejecución de la consulta
            //context.Products.InsertOnSubmit(p);
            //context.SubmitChanges();

            // *

            // Implemente el código necesario para insertar un registro en la tabla Categories
            //Categories c = new Categories();
            //c.CategoryName = "Drinks";
            //c.Description = "Soda, Whisky, etc.";            

            //// Ejecución de la consulta
            //context.Categories.InsertOnSubmit(c);
            //context.SubmitChanges();

            // *

            //var product = (from p in context.Products
            //               where p.ProductName == "Tofu"
            //               select p).FirstOrDefault();
            //product.UnitPrice = 100;
            //product.UnitsInStock = 15;
            //product.Discontinued = true;
            //// ejecución de la consulta            
            //context.SubmitChanges();

            //var product = (from p in context.Products
            //               where p.ProductID == 78
            //               select p).FirstOrDefault();
            ////// ejecución de la consulta            
            //context.Products.DeleteOnSubmit(product);
            //context.SubmitChanges();

            //var query3 = from pq3 in context.Products
            //             where pq3.CategoryID == 1
            //             select pq3;

            //foreach(var prod3 in query3){
            //    Console.WriteLine("ID={0} \t Name={1} \t Price={2} \t Stock={3}",prod3.ProductID, prod3.ProductName, prod3.UnitPrice, prod3.UnitsInStock);
            //}

            // Actividades adicionales:
            // Listar ID, nombre de producto, nombre del proveedor (Suppliers/CompanyName) productos de los productos de la categoría “Dairy Products”
            //var query4 = from pq3 in context.Products
            //             where pq3.Categories.CategoryName == "Dairy Products"
            //             select pq3;

            //foreach (var prod3 in query4)
            //{
            //    Console.WriteLine("ID={0} \t Name={1} \t Suppliers={2} ", prod3.ProductID, prod3.ProductName, prod3.Suppliers.CompanyName);
            //}

            // Listar los productos de los proveedores ubicados en USA
            var query5 = from pq3 in context.Products
                         where pq3.Suppliers.Country == "USA"
                         select pq3;

            foreach (var prod3 in query5)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Country={2} \t Suppliers={3} ", prod3.ProductID, prod3.ProductName, prod3.Suppliers.Country, prod3.Suppliers.CompanyName);
            }

            Console.ReadKey();

        }
    }
}
