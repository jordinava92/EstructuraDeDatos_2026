using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("        RETO DE PROGRAMACIÓN: CALCULADORA DE POLÍGONOS REGULARES      ");
        Console.WriteLine("=====================================================================");

        while (true)
        {
            // 1. Selección del polígono mediante la función correspondiente
            int numLados = SeleccionarPoligono();

            // Si el usuario elige la opción de salir (0), rompemos el ciclo
            if (numLados == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n¡Programa finalizado con éxito! Hasta luego.");
                Console.ResetColor();
                break;
            }

            // 2. Solicitar los datos (Lado y Apotema) usando paso por referencia (out)
            PedirDatos(out double medidaLado, out double apotema);

            // 3. Calcular el área con la función dedicada
            double areaResultado = CalcularArea(numLados, medidaLado, apotema);

            // Mostrar el resultado de manera elegante
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n> El perímetro del polígono es: {numLados * medidaLado} u.");
            Console.WriteLine($"> El área total calculada es: {areaResultado:F4} u²");
            Console.ResetColor();
            
            Console.WriteLine("\nPresiona cualquier tecla para realizar otro cálculo...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // =====================================================================
    // 1. FUNCIÓN: SeleccionarPoligono
    // Muestra el menú interactivo y retorna el número de lados del polígono elegido
    // =====================================================================
    public static int SeleccionarPoligono()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENÚ DE SELECCIÓN ---");
            Console.WriteLine("1) Pentágono (5 lados)");
            Console.WriteLine("2) Hexágono (6 lados)");
            Console.WriteLine("3) Heptágono (7 lados)");
            Console.WriteLine("4) Octágono (8 lados)");
            Console.WriteLine("0) Salir del programa");
            Console.Write("\nSelecciona una opción: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1: return 5;
                    case 2: return 6;
                    case 3: return 7;
                    case 4: return 8;
                    case 0: return 0;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida. Intenta con un número del menú.");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Por favor ingresa un número entero válido.");
                Console.ResetColor();
            }
        }
    }

    // =====================================================================
    // 2. FUNCIÓN: PedirDatos
    // Solicita de forma segura la longitud del lado y la apotema (Valida > 0)
    // =====================================================================
    public static void PedirDatos(out double lado, out double apotema)
    {
        Console.WriteLine("\n--- INGRESO DE MEDICIONES ---");
        
        // Validación para la medida del lado
        while (true)
        {
            Console.Write("Ingresa la medida de un lado: ");
            if (double.TryParse(Console.ReadLine(), out lado) && lado > 0)
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Error: La longitud debe ser un número mayor a cero.");
            Console.ResetColor();
        }

        // Validación para la apotema
        while (true)
        {
            Console.Write("Ingresa la medida de la apotema: ");
            if (double.TryParse(Console.ReadLine(), out apotema) && apotema > 0)
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Error: La apotema debe ser un número mayor a cero.");
            Console.ResetColor();
        }
    }

    // =====================================================================
    // 3. FUNCIÓN: CalcularArea
    // Recibe los parámetros necesarios y devuelve el área: (Perímetro * Apotema) / 2
    // =====================================================================
    public static double CalcularArea(int lados, double longitudLado, double apotema)
    {
        double parametroPerimetro = lados * longitudLado;
        double areaCalculada = (parametroPerimetro * apotema) / 2.0;
        return areaCalculada;
    }
}