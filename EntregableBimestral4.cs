using System;

// 1. Caso base: Detiene la recursividad y empieza a desapilar
int CalcularFactorial(int n)
{
    if (n <= 1) return 1;
    return n * CalcularFactorial(n - 1);
}

// 2. Llamada de prueba para ver el resultado en la terminal
int resultado = CalcularFactorial(3);
Console.WriteLine($"El factorial de 3 es: {resultado}");
