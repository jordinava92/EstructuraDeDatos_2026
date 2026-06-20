using System;

class Program
{
    static void Main(string[] args)
    {
        // 5. Usé try-catch en el método Main para capturar errores
        try
        {
            Console.WriteLine("--- Probando Factorial ---");
            int numeroFactorial = 3;
            int resultadoFactorial = CalcularFactorial(numeroFactorial);
            Console.WriteLine($"El factorial de {numeroFactorial} es: {resultadoFactorial}");

            Console.WriteLine("\n--- Probando Fibonacci ---");
            int numeroFibonacci = 6;
            int resultadoFibonacci = GenerarFibonacci(numeroFibonacci);
            Console.WriteLine($"El término {numeroFibonacci} de Fibonacci es: {resultadoFibonacci}");

            // Prueba de validación de negativos (descomenta para probar el catch)
            // CalcularFactorial(-5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\n[ERROR DE VALIDACIÓN]: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERROR INESPERADO]: {ex.Message}");
        }
    }

    // 2. Implementé CalcularFactorial(int n) con caso base correcto
    // 4. Añadí validación para entradas negativas
    static int CalcularFactorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("El número no puede ser negativo para calcular el factorial.");
        }

        // Caso base
        if (n <= 1) return 1;

        // Paso recursivo
        return n * CalcularFactorial(n - 1);
    }

    // 3. Implementé GenerarFibonacci(int n) con dos casos base
    // 4. Añadí validación para entradas negativas
    static int GenerarFibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("El número no puede ser negativo para la serie de Fibonacci.");
        }

        // Dos casos base (Fibonacci de 0 es 0, de 1 es 1)
        if (n == 0) return 0;
        if (n == 1) return 1;

        // Paso recursivo
        return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
    }
}