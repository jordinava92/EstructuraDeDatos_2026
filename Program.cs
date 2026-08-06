using System;

namespace DataCore.Fase3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBAS FASE 3: TABLA DINÁMICA ===");

            // 1. Crear la lista dinámica
            TablaDinamica lista = new TablaDinamica();

            // 2. Probar inserciones (Asegúrate de ajustar los parámetros según tu clase RegistroDatos)
            Console.WriteLine("Insertando elementos...");
            // Ejemplo: lista.Insertar(new RegistroDatos { Id = 1, Nombre = "Test" });

            Console.WriteLine($"Total de elementos en lista: {lista.Cantidad}");

            // 3. Probar conversión a arreglo
            var arreglo = lista.AArreglo();
            Console.WriteLine($"Elementos convertidos a arreglo: {arreglo.Length}");

            Console.WriteLine("\n¡Ejecución completada con éxito!");
        }
    }
}