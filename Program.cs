using System;
using System.Diagnostics;

namespace EstructuraDeDatos_2026
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamaño = 10_000;
            RegistroDatos[] arregloOriginal = GenerarArregloAleatorio(tamaño);

            // Clonar arreglos para garantizar condiciones idénticas de prueba
            RegistroDatos[] copiaSeleccion = (RegistroDatos[])arregloOriginal.Clone();
            RegistroDatos[] copiaQuickSort = (RegistroDatos[])arregloOriginal.Clone();

            // --- BENCHMARK 1: Selección (Fase 1) ---
            int contadorComparaciones = 0;
            int contadorIntercambios = 0;

            Stopwatch swSeleccion = Stopwatch.StartNew();
            
            // Llama a tu método de Selección de la Fase 1
            Fase1.OrdenarPorSeleccion(copiaSeleccion, ref contadorComparaciones, ref contadorIntercambios);
            
            swSeleccion.Stop();
            long msSeleccion = swSeleccion.ElapsedMilliseconds;

            // Verificación de correctitud Fase 1
            if (!EstaOrdenado(copiaSeleccion))
                Console.WriteLine("[ERROR] El arreglo ordenado por Selección Directa contiene fallos.");

            // --- BENCHMARK 2: QuickSort (Fase 2) ---
            Fase2.contadorLlamadas = 0;

            Stopwatch swQuickSort = Stopwatch.StartNew();
            
            // Llama al método estático QuickSort de la Fase 2
            Fase2.QuickSort(copiaQuickSort, 0, copiaQuickSort.Length - 1);
            
            swQuickSort.Stop();
            long msQuickSort = swQuickSort.ElapsedMilliseconds;

            // Verificación de correctitud Fase 2
            if (!EstaOrdenado(copiaQuickSort))
            {
                Console.WriteLine("[ERROR] El arreglo ordenado por QuickSort contiene fallos.");
            }
            else
            {
                Console.WriteLine("OK: ordenamiento correcto");
            }

            Console.WriteLine(); // Espacio visual antes del reporte

            // --- REPORTE COMPARATIVO DE SALIDA (Formato oficial) ---
            Console.WriteLine("==================================================");
            Console.WriteLine($"   REPORTE COMPARATIVO DE ORDENAMIENTO (n = {tamaño:N0})");
            Console.WriteLine("==================================================");
            Console.WriteLine("Algoritmo            : Selección Directa");
            Console.WriteLine($"Registros procesados : {tamaño:N0}");
            Console.WriteLine($"Comparaciones        : {contadorComparaciones:N0}");
            Console.WriteLine($"Intercambios         : {contadorIntercambios:N0}");
            Console.WriteLine($"Tiempo de ejecución  : {msSeleccion} ms");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Algoritmo            : QuickSort");
            Console.WriteLine($"Registros procesados : {tamaño:N0}");
            Console.WriteLine($"Llamadas recursivas  : {Fase2.contadorLlamadas:N0}");
            Console.WriteLine($"Tiempo de ejecución  : {msQuickSort} ms");
            Console.WriteLine("--------------------------------------------------");

            double ratio = msQuickSort > 0 ? (double)msSeleccion / msQuickSort : 0;
            Console.WriteLine($"Ratio de velocidad  : QuickSort fue {ratio:F1}x más rápido");
            Console.WriteLine("==================================================");
        }

        /// <summary>
        /// Método de verificación estático para comprobar si el arreglo quedó ordenado ascendente por Id.
        /// </summary>
        static bool EstaOrdenado(RegistroDatos[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].Id > arr[i + 1].Id)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Genera un conjunto reproducible de registros pseudoaleatorios usando una semilla fija (42).
        /// </summary>
        static RegistroDatos[] GenerarArregloAleatorio(int cantidad)
        {
            Random rnd = new Random(42); // Semilla fija obligatoria
            RegistroDatos[] arreglo = new RegistroDatos[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                int id = rnd.Next(1, 100_001);
                string hashValidacion = Guid.NewGuid().ToString();
                double pesoBytes = 1.0 + (rnd.NextDouble() * 9999.0);

                arreglo[i] = new RegistroDatos(id, hashValidacion, pesoBytes);
            }

            return arreglo;
        }
    }
}