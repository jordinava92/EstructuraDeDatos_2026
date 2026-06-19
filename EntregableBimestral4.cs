using System;
using System.Collections.Generic;
using System.Linq;

namespace EstructuraDeDatos
{
    public class Program
    {
        public static void Main()
        {
            // 1. Inicialización de la lista de productos
            List<Producto> productos = new List<Producto>
            {
                new Producto { Nombre = "Laptop", Precio = 800.0, Cantidad = 5 },
                new Producto { Nombre = "Mouse", Precio = 25.0, Cantidad = 20 },
                new Producto { Nombre = "Teclado", Precio = 60.0, Cantidad = 10 },
                new Producto { Nombre = "Monitor", Precio = 250.0, Cantidad = 15 },
                new Producto { Nombre = "Cable HDMI", Precio = 15.0, Cantidad = 30 },
                new Producto { Nombre = "Audífonos", Precio = 75.0, Cantidad = 12 }
            };

            // 2. Consulta LINQ: Filtrar precio > 50 y ordenar por cantidad descendente
            var productosFiltradosYOrdenados = productos
                .Where(p => p.Precio > 50)
                .OrderByDescending(p => p.Cantidad)
                .ToList();

            // 3. Impresión de los resultados filtrados en la consola
            Console.WriteLine("--- Productos con precio > $50 (Ordenados de mayor a menor cantidad) ---");
            
            foreach (var producto in productosFiltradosYOrdenados)
            {
                Console.WriteLine($"- {producto.Nombre}: ${producto.Precio} | Cantidad: {producto.Cantidad}");
            }
        }
    }

    // 4. Definición de la clase Producto con sus propiedades encapsuladas
    public class Producto
    {
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}