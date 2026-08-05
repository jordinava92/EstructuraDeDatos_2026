using System;

namespace AlgoritmoBurbuja
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("       DEMOSTRACIÓN DE ORDENAMIENTO BURBUJA       ");
                Console.WriteLine("==================================================\n");

                // 1. Módulo de generación aleatoria del arreglo (100 elementos)
                int tamano = 100;
                int[] arregloOriginal = GenerarArregloAleatorio(tamano, 1, 500);

                int[] arreglo = (int[])arregloOriginal.Clone();

                // Evidencia 1: Arreglo inicial desordenado
                Console.WriteLine("--- EVIDENCIA 1: ARREGLO INICIAL DESORDENADO ---");
                ImprimirArreglo(arreglo);
                Console.WriteLine();

                // 2. Módulo de ordenamiento mediante el Método Burbuja
                Console.WriteLine("--- EJECUTANDO ALGORITMO BUBBLE SORT ---");
                long totalIntercambios = OrdenarPorBurbuja(arreglo);
                Console.WriteLine("Ordenamiento completado exitosamente.\n");

                // Evidencia 2: Arreglo final ordenado de 0 a 100
                Console.WriteLine("--- EVIDENCIA 2: ARREGLO FINAL ORDENADO ---");
                ImprimirArreglo(arreglo);
                Console.WriteLine();

                // Evidencia 3: Total exacto de intercambios realizados
                Console.WriteLine("==================================================");
                Console.WriteLine($" EVIDENCIA 3: TOTAL DE INTERCAMBIOS REALIZADOS = {totalIntercambios}");
                Console.WriteLine("==================================================");
            }
            catch (Exception ex)
            {
                // Módulo de banco de pruebas y manejo de errores try-catch
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR]: Ocurrió un fallo inesperado durante la ejecución:");
                Console.WriteLine($"Detalles: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para finalizar el programa...");
            Console.ReadKey();
        }

        /// <summary>
        /// Genera un arreglo de enteros con valores aleatorios.
        /// </summary>
        /// <param name="cantidad">Número de elementos a generar.</param>
        /// <param name="min">Valor mínimo posible.</param>
        /// <param name="max">Valor máximo posible.</param>
        /// <returns>Arreglo de enteros desordenado.</returns>
        static int[] GenerarArregloAleatorio(int cantidad, int min, int max)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("El tamaño del arreglo debe ser mayor a cero.");
            }

            Random random = new Random();
            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = random.Next(min, max + 1);
            }

            return arreglo;
        }

        /// <summary>
        /// Ordena un arreglo de enteros utilizando el algoritmo Bubble Sort
        /// y contabiliza el número exacto de intercambios.
        /// </summary>
        /// <param name="arreglo">Arreglo a ordenar.</param>
        /// <returns>Total de intercambios realizados.</returns>
        static long OrdenarPorBurbuja(int[] arreglo)
        {
            if (arreglo == null || arreglo.Length == 0)
            {
                throw new ArgumentNullException(nameof(arreglo), "El arreglo no puede ser nulo ni estar vacío.");
            }

            long contadorIntercambios = 0;
            int n = arreglo.Length;
            bool huboIntercambio;

            for (int i = 0; i < n - 1; i++)
            {
                huboIntercambio = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arreglo[j] > arreglo[j + 1])
                    {
                        // Intercambio de posición
                        int temporal = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = temporal;

                        contadorIntercambios++;
                        huboIntercambio = true;
                    }
                }

                // Optimización: si en una pasada no hubo intercambios, ya está ordenado
                if (!huboIntercambio)
                {
                    break;
                }
            }

            return contadorIntercambios;
        }

        /// <summary>
        /// Imprime los elementos de un arreglo formateados en consola en filas de 10.
        /// </summary>
        /// <param name="arreglo">Arreglo a imprimir.</param>
        static void ImprimirArreglo(int[] arreglo)
        {
            if (arreglo == null) return;

            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write($"[{arreglo[i]:D3}] ");
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}