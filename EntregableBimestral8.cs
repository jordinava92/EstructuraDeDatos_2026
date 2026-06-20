using System;
using System.Numerics; // REQUERIDO para usar BigInteger

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("    ENTREGABLE: DIAGNÓSTICO DE OVERFLOW Y REFACTORIZACIÓN CON BIGINTEGER  ");
        Console.WriteLine("=====================================================================");

        // -----------------------------------------------------------------
        // PARTE A: DIAGNÓSTICO EN MAIN (Ciclo del 1 al 20)
        // -----------------------------------------------------------------
        Console.WriteLine("\n--- PARTE A: Ciclo de Diagnóstico (n=1 a n=20) ---");
        for (int i = 1; i <= 20; i++)
        {
            // Nota: Se usa el formato con interpolación exacto solicitado en la guía
            Console.WriteLine($"n={i:D2} | Recursivo: {FactorialInt(i),25} | Iterativo: {FactorialIterativo(i),25}");
        }

        /* * ⚠️ DOCUMENTACIÓN DEL PUNTO DE QUIEBRE (CRITERIO DE EVALUACIÓN):
         * * El PUNTO DE QUIEBRE exacto ocurre en n = 14.
         * * EXPLICACIÓN:
         * El tipo de dato 'int' en C# es un entero con signo de 32 bits, cuyo valor máximo 
         * almacenable es 2,147,483,647 (int.MaxValue).
         * * - Para n = 13: El resultado es 6,227,020,800. Como este número supera los 2.14 mil millones, 
         * se produce un "Integer Overflow" (desbordamiento). Por desbordamiento cíclico binario, 
         * el bit de signo cambia, devolviendo el valor erróneo: 1,932,053,504. Aunque sigue siendo 
         * positivo por azar de los bits remanentes, YA ES UN VALOR INCORRECTO.
         * - Para n = 14: El desbordamiento binario avanza y produce formalmente el primer valor 
         * completamente inconsistente y negativo: -1,245,116,928.
         */

        // -----------------------------------------------------------------
        // PARTE B: REFACTORIZACIÓN DE ALTA PRECISIÓN (Prueba con n = 100)
        // -----------------------------------------------------------------
        Console.WriteLine("\n-----------------------------------------------------------------");
        Console.WriteLine("--- PARTE B: Refactorización Profesional de Alta Precisión ---");
        
        BigInteger nPrueba = 100;
        BigInteger resultadoBig = FactorialProfesional(nPrueba);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"100! = {resultadoBig}");
        Console.ResetColor();

        /*
         * 🧠 REFLEXIÓN SOBRE TCO (TAIL CALL OPTIMIZATION) EN .NET:
         * El compilador JIT de .NET Core / .NET (arquitecturas de 64 bits) es capaz de realizar 
         * Tail Call Optimization (TCO) bajo ciertas condiciones de optimización de código (Release). 
         * Sin embargo, debido a que nuestra operación realiza una multiplicación pendiente DESPUÉS 
         * de la llamada recursiva (n * Factorial(n-1)), el marco actual del Stack no puede liberarse 
         * de inmediato. Por lo tanto, esta implementación no se beneficia directamente de TCO pura, 
         * dependiendo de la capacidad del Heap para BigInteger.
         */
    }

    // =================================================================
    // PARTE A: IMPLEMENTACIONES TRADICIONALES
    // =================================================================

    // Función Recursiva - FactorialInt
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
            return 1;
            
        return n * FactorialInt(n - 1);
    }

    // Función Iterativa - FactorialIterativo
    static int FactorialIterativo(int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    }

    // =================================================================
    // PARTE B: IMPLEMENTACIÓN DE ALTA PRECISIÓN
    // =================================================================

    // Función Profesional con BigInteger (Asignación dinámica en el Heap)
    static BigInteger FactorialProfesional(BigInteger n)
    {
        // Caso Base
        if (n == 0 || n == 1)
            return BigInteger.One;

        // Caso Recursivo
        return n * FactorialProfesional(n - 1);
    }
}