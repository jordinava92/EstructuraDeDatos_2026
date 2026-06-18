using System;

namespace CalculadorPoligonos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- BIENVENIDO AL CALCULADOR DE ÁREAS DE POLÍGONOS REGULARES ---");
            
            // 1. Selección del polígono
            int numLados = SeleccionarPoligono();
            
            // Si el usuario eligió salir o una opción inválida, terminamos el programa
            if (numLados == 0)
            {
                Console.WriteLine("\nPrograma finalizado. ¡Hasta luego!");
                return;
            }

            // 2. Petición de datos (usamos 'out' para devolver múltiples valores)
            PedirDatos(out double medidaLado, out double apotema);

            // 3. Cálculo del área
            double areaFinal = CalcularArea(numLados, medidaLado, apotema);

            // Mostrar el resultado
            Console.WriteLine("\n========================================");
            Console.WriteLine($" El área del polígono de {numLados} lados es: {areaFinal:F2} unidades cuadradas.");
            Console.WriteLine("========================================");
            
            Console.ReadLine();
        }

        /// <summary>
        /// Muestra un menú y devuelve el número de lados según la opción seleccionada.
        /// </summary>
        static int SeleccionarPoligono()
        {
            Console.WriteLine("\nSeleccione el tipo de polígono regular:");
            Console.WriteLine("1. Pentágono (5 lados)");
            Console.WriteLine("2. Hexágono (6 lados)");
            Console.WriteLine("3. Heptágono (7 lados)");
            Console.WriteLine("4. Octágono (8 lados)");
            Console.WriteLine("5. Salir");
            Console.Write("Elija una opción (1-5): ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": return 5;
                case "2": return 6;
                case "3": return 7;
                case "4": return 8;
                case "5": return 0;
                default:
                    Console.WriteLine("Opción no válida. Se cerrará el programa.");
                    return 0;
            }
        }

        /// <summary>
        /// Solicita al usuario la medida del lado y la apotema mediante parámetros de salida (out).
        /// </summary>
        static void PedirDatos(out double lado, out double apotema)
        {
            Console.WriteLine("\n--- Captura de Datos ---");
            
            Console.Write("Introduce la medida de uno de los lados: ");
            while (!double.TryParse(Console.ReadLine(), out lado) || lado <= 0)
            {
                Console.Write("Por favor, introduce un número válido y mayor a 0 para el lado: ");
            }

            Console.Write("Introduce la medida de la apotema: ");
            while (!double.TryParse(Console.ReadLine(), out apotema) || apotema <= 0)
            {
                Console.Write("Por favor, introduce un número válido y mayor a 0 para la apotema: ");
            }
        }

        /// <summary>
        /// Recibe los datos del polígono y devuelve el área calculada.
        /// </summary>
        static double CalcularArea(int lados, double medidaLado, double apotema)
        {
            // Fórmula: Área = (Perímetro * Apotema) / 2
            double perimetro = lados * medidaLado;
            double area = (perimetro * apotema) / 2;
            return area;
        }
    }
}