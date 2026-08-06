using System;

namespace DataCore.Fase3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar la estructura dinámica
            TablaDinamica dataCore = new TablaDinamica();

            // Paso 1: Insertar 15 registros dinámicos
            for (int i = 1; i <= 15; i++)
            {
                RegistroDatos reg = new RegistroDatos(i, $"Transacción-{i}", i * 100.0m);
                dataCore.InsertarFinal(reg);
                Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
            }

            // Paso 2: Eliminar 2 registros específicos
            Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
            dataCore.EliminarPorId(5);
            dataCore.EliminarPorId(11);
            Console.WriteLine("Cadena reestructurada exitosamente. Sin NullReferenceException.");

            // Paso 3: Convertir a arreglo
            RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();
            Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");

            // Paso 4: Ordenar con QuickSort (Fase 2)
            // InteroperabilidadFase3.OrdenarListaConQuickSort(dataCore); // O llamar al algoritmo directo
            
            Console.WriteLine("\n--- Arreglo ordenado por Id (QuickSort) ---");
            foreach (var r in arreglo)
            {
                Console.WriteLine($"Id: {r.Id} | Nombre: {r.Nombre} | Monto: {r.Monto:C}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            // Console.ReadKey(); // Opcional si ejecutas desde VS Code
        }
    }
}