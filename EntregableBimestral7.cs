using System;

class Program
{
    // =========================================================
    // 1. MENÚ PRINCIPAL Y CONTROL DE FLUJO
    // =========================================================
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================================");
            Console.WriteLine("   PRÁCTICA DE CALL STACK Y RECURSIVIDAD (UNITEC)      ");
            Console.WriteLine("=======================================================");
            Console.ResetColor();
            Console.WriteLine("1. Ejercicio A: Cuenta Regresiva de Memoria (Efecto LIFO)");
            Console.WriteLine("2. Ejercicio B: Sumatoria Recursiva Dinámica (Validación Robusta)");
            Console.WriteLine("3. Salir del Programa");
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Selecciona una opción (1-3): ");
            
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    EjecutarEjercicioA();
                    break;
                case "2":
                    EjecutarEjercicioB();
                    break;
                case "3":
                    continuar = false;
                    Console.WriteLine("\n¡Mucho éxito en tus estudios de Estructura de Datos! Saliendo...");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌ Opción no válida. Presiona cualquier tecla para intentar de nuevo.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }

    // =========================================================
    // 2. CONTROLADOR Y LÓGICA DEL EJERCICIO A
    // =========================================================
    static void EjecutarEjercicioA()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- EJERCICIO A: CUENTA REGRESIVA DE MEMORIA (LIFO) ---");
        Console.ResetColor();
        Console.WriteLine("Ejecutando simulación con n = 3...\n");

        // Llamada inicial al método recursivo
        ImprimirCuentaRegresiva(3);

        Console.WriteLine("\n-------------------------------------------------------");
        Console.WriteLine("Presiona cualquier tecla para regresar al menú principal.");
        Console.ReadKey();
    }

    static void ImprimirCuentaRegresiva(int numero)
    {
        // Caso Base
        if (numero < 1)
        {
            return;
        }

        // Acción en Fase de Apilación (Push)
        Console.WriteLine($"Iniciando marco para: {numero}");

        // Llamada Recursiva
        ImprimirCuentaRegresiva(numero - 1);

        // Acción en Fase de Libeación / Desapilación (Pop)
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"💥 Memoria LIBERADA para el número: {numero}");
        Console.ResetColor();
    }

    // =========================================================
    // 3. CONTROLADOR Y LÓGICA DEL EJERCICIO B
    // =========================================================
    static void EjecutarEjercicioB()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- EJERCICIO B: SUMATORIA RECURSIVA DINÁMICA ---");
        Console.ResetColor();
        Console.Write("Por favor, ingresa un número entero positivo: ");
        string entrada = Console.ReadLine();

        // Validación robusta de entrada con int.TryParse
        if (!int.TryParse(entrada, out int numeroValidado))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ ERROR: La entrada no es un número entero válido.");
            Console.ResetColor();
            FinalizarEjercicioB();
            return;
        }

        // Manejo profesional de excepciones con bloques try-catch
        try
        {
            int resultado = SumarHasta(numeroValidado);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ ¡Éxito! La sumatoria de 1 hasta {numeroValidado} es: {resultado}");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n⚠️ ERROR DE ARGUMENTO: {ex.Message}");
            Console.ResetColor();
        }
        catch (OverflowException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💥 ERROR DE DESBORDAMIENTO: El número es demasiado grande y superó la capacidad del tipo 'int' en la RAM (Integer Overflow).");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Ocurrió un error inesperado: {ex.Message}");
        }

        FinalizarEjercicioB();
    }

    static int SumarHasta(int n)
    {
        // Defensa temprana contra infinitos negativos antes de romper el Stack
        if (n < 0)
        {
            throw new ArgumentException("El número debe ser mayor o igual a cero. La recursión no puede avanzar hacia el infinito negativo.");
        }

        if (n == 0) return 0;
        if (n == 1) return 1;

        // Activamos checked para forzar la detección de desbordamientos aritméticos en la pila
        checked
        {
            return n + SumarHasta(n - 1);
        }
    }

    static void FinalizarEjercicioB()
    {
        Console.WriteLine("\n-------------------------------------------------------");
        Console.WriteLine("Presiona cualquier tecla para regresar al menú principal.");
        Console.ReadKey();
    }
}