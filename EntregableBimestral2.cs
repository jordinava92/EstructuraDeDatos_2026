using System;

namespace RetoMemoria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== RETO DE PROGRAMACIÓN: EL DEMONIO DE LA MEMORIA ===\n");

            // --- CASO 1: PASO POR VALOR (int) ---
            int numeroOriginal = 10;
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. CASO: Tipo de Valor (int)");
            Console.WriteLine($"   Antes de la función: El número vale = {numeroOriginal}");
            
            // Se envía una COPIA del valor de la variable
            CambiarValor(numeroOriginal);
            
            Console.WriteLine($"   Después de la función: El número vale = {numeroOriginal}");
            Console.WriteLine("   -> CONCLUSIÓN: El valor original NO CAMBIÓ porque la función modificó una copia.");
            Console.WriteLine("--------------------------------------------------\n");


            // --- CASO 2: PASO POR REFERENCIA (int[]) ---
            int[] arregloOriginal = { 10, 20, 30 };
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("2. CASO: Tipo de Referencia (int[])");
            Console.WriteLine($"   Antes de la función: El primer elemento vale = {arregloOriginal[0]}");
            
            // Se envía la DIRECCIÓN DE MEMORIA del arreglo original
            CambiarReferencia(arregloOriginal);
            
            Console.WriteLine($"   Después de la función: El primer elemento vale = {arregloOriginal[0]}");
            Console.WriteLine("   -> CONCLUSIÓN: El valor original SÍ CAMBIÓ porque la función accedió a la misma dirección de memoria.");
            Console.WriteLine("--------------------------------------------------");

            Console.ReadLine();
        }

        /// <summary>
        /// Recibe un entero por VALOR. 
        /// Crea una copia local en una sección diferente de la memoria stack.
        /// </summary>
        static void CambiarValor(int x)
        {
            x = 100; // Esto solo afecta a la copia local 'x'
        }

        /// <summary>
        /// Recibe un arreglo por REFERENCIA.
        /// Copia la dirección que apunta al objeto real guardado en la memoria Heap.
        /// </summary>
        static void CambiarReferencia(int[] arr)
        {
            if (arr != null && arr.Length > 0)
            {
                arr[0] = 100; // Modifica directamente el objeto en el Heap
            }
        }
    }
}