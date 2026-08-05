using System;
using System.Collections.Generic;

namespace AlgoritmosBusqueda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" CLASE 15: ALGORITMOS DE BÚSQUEDA Y EVALUACIÓN DE RENDIMIENTO DE CÓDIGO ");
            Console.WriteLine("=========================================================================\n");

            int totalRegistros = 10000;
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // 1. Generación de un conjunto de 10,000 registros ordenados
            Console.WriteLine($"[+] Generando base de datos sintética con {totalRegistros:N0} estudiantes...");
            for (int i = 1; i <= totalRegistros; i++)
            {
                listaEstudiantes.Add(new Estudiante(i, $"Estudiante_{i}"));
            }

            // 2. Definición del caso de prueba (Matrícula en extremo superior para forzar el peor caso en Búsqueda Lineal)
            int matriculaObjetivo = 9998;
            Console.WriteLine($"[+] Matrícula objetivo a buscar: {matriculaObjetivo}\n");

            // 3. Ejecución de Búsqueda Lineal O(n)
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("1. EJECUCIÓN: Búsqueda Lineal O(n)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Estudiante resultadoLineal = BuscadorMatriculas.BusquedaLineal(listaEstudiantes, matriculaObjetivo, out int iteracionesLineal);
            
            if (resultadoLineal != null)
            {
                Console.WriteLine($"Resultado : {resultadoLineal}");
                Console.WriteLine($"Iteraciones ejecutadas: {iteracionesLineal:N0}");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }

            // 4. Ejecución de Búsqueda Binaria O(log n)
            Console.WriteLine("\n-------------------------------------------------------------------------");
            Console.WriteLine("2. EJECUCIÓN: Búsqueda Binaria O(log n)");
            Console.WriteLine("-------------------------------------------------------------------------");
            Estudiante resultadoBinario = BuscadorMatriculas.BusquedaBinaria(listaEstudiantes, matriculaObjetivo, out int iteracionesBinaria);
            
            if (resultadoBinario != null)
            {
                Console.WriteLine($"Resultado : {resultadoBinario}");
                Console.WriteLine($"Iteraciones ejecutadas: {iteracionesBinaria}");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }

            // 5. Reporte comparativo de rendimiento
            Console.WriteLine("\n=========================================================================");
            Console.WriteLine(" REPORTE COMPARATIVO DE RENDIMIENTO ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine($"* Iteraciones Búsqueda Lineal : {iteracionesLineal:N0}");
            Console.WriteLine($"* Iteraciones Búsqueda Binaria: {iteracionesBinaria}");
            Console.WriteLine($"* Reducción de operaciones    : {((double)(iteracionesLineal - iteracionesBinaria) / iteracionesLineal * 100):F2}%");
            Console.WriteLine("=========================================================================");
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}