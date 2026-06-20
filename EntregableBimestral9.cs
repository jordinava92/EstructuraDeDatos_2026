using System;
using System.Diagnostics; // REQUERIDO para el uso de Stopwatch

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("  MÓDULO C: BANCO DE PRUEBAS - ANÁLISIS DE RENDIMIENTO (FIBONACCI)   ");
        Console.WriteLine("=====================================================================");
        
        Console.Write("Ingresa un número (35-43): ");
        string input = Console.ReadLine();

        // 1. VALIDACIÓN DE ENTRADA ROBUSTA (Rechaza texto, vacíos, negativos o n > 50)
        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: ingresa un número positivo.");
            Console.ResetColor();
            return;
        }
        
        if (n > 50)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Alerta: Valores mayores a 50 con el método inseguro congelarán tu CPU por horas.");
            Console.ResetColor();
            return;
        }

        // Instancia del cronómetro de alta resolución
        Stopwatch sw = new Stopwatch();

        // =================================================================
        // EJECUCIÓN 1: MÉTODO INSEGURO (FUERZA BRUTA) - MÓDULO A
        // =================================================================
        Console.WriteLine("\n--- Calculando con Método Inseguro (Fuerza Bruta) ---");
        sw.Restart();
        long r1 = FibonacciInseguro(n);
        sw.Stop();
        
        Console.WriteLine($"Inseguro: F({n}) = {r1}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
        Console.ResetColor();

        // =================================================================
        // EJECUCIÓN 2: MÉTODO PRO (MEMOIZATION) - MÓDULO B
        // =================================================================
        Console.WriteLine("\n--- Calculando con Método Pro (Memoization) ---");
        
        // Inicialización del arreglo Caché en -1 (Indica término no calculado aún)
        long[] cache = new long[n + 1];
        for (int i = 0; i <= n; i++)
        {
            cache[i] = -1;
        }

        sw.Restart();
        long r2 = FibonacciPro(n, cache);
        sw.Stop();

        Console.WriteLine($"Pro: F({n}) = {r2}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
        Console.ResetColor();
        
        Console.WriteLine("\n=====================================================================");
        Console.WriteLine("ANÁLISIS DE COMPLEJIDAD:");
        Console.WriteLine("- Método Inseguro: Complejidad Exponencial O(2^n). Genera millones de llamadas duplicadas.");
        Console.WriteLine("- Método Pro: Complejidad Lineal O(n). Reduce el cálculo a una única pasada gracias a la memoria caché.");
    }

    // =================================================================
    // MÓDULO A: FIBONACCI RECURSIVO TRADICIONAL (FUERZA BRUTA)
    // =================================================================
    public static long FibonacciInseguro(int n)
    {
        // Casos Base
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        // Llamada Recursiva Redundante (Bifurcación Doble Exponencial)
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    // =================================================================
    // MÓDULO B: FIBONACCI CON MEMOIZATION (ESTRATEGIA PRO)
    // =================================================================
    public static long FibonacciPro(int n, long[] cache)
    {
        // Casos Base
        if (n == 0) return 0;
        if (n == 1) return 1;

        // ¿Ya lo calculamos antes? Verificación del centela (-1)
        if (cache[n] != -1)
        {
            return cache[n]; // Retorno inmediato O(1)
        }

        // Calcular, almacenar en caché y retornar
        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}