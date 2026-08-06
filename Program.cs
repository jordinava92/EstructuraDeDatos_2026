using System;
using DataCore.Fase4;

namespace DataCore
{
    class Program
    {
        private static TablaDinamica baseDeDatos = new TablaDinamica();
        private static RegistroDatos[]? indiceOrdenado = null;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                MostrarEncabezadoMenu();

                Console.Write("Seleccione una opción (1-6): ");
                string? input = Console.ReadLine();

                // Validación de entrada con TryParse
                if (!int.TryParse(input, out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERROR UX] Entrada inválida. Por favor, ingrese un número entero positivo.");
                    Console.ResetColor();
                    Pausar();
                    continue;
                }

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            EjecutarInsertar();
                            break;
                        case 2:
                            EjecutarEliminar();
                            break;
                        case 3:
                            EjecutarMostrarTodo();
                            break;
                        case 4:
                            EjecutarIndexarYOrdenar();
                            break;
                        case 5:
                            EjecutarBusquedaBinaria();
                            break;
                        case 6:
                            Console.WriteLine("\nCerrando el sistema DataCore de forma segura...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n[ADVERTENCIA] Opción fuera de rango. Seleccione un número entre 1 y 6.");
                            Console.ResetColor();
                            Pausar();
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR FORMATO] {ex.Message}");
                    Console.ResetColor();
                    Logger.RegistrarExcepcion(ex, $"Opción {opcion}");
                    Pausar();
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[OPERACIÓN INVÁLIDA] {ex.Message}");
                    Console.ResetColor();
                    Logger.RegistrarExcepcion(ex, $"Opción {opcion}");
                    Pausar();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR INESPERADO] {ex.Message}");
                    Console.ResetColor();
                    Logger.RegistrarExcepcion(ex, $"Opción {opcion}");
                    Pausar();
                }

            } while (opcion != 6);
        }

        private static void MostrarEncabezadoMenu()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("        SISTEMA DATACORE - MENÚ MAESTRO       ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Insertar Registro (Fase 1 - Lista Enlazada)");
            Console.WriteLine("2. Eliminar por ID   (Fase 2 - Gestión Nodos)");
            Console.WriteLine("3. Mostrar Registros (Fase 1 - Travesía)");
            Console.WriteLine("4. Indexar y Ordenar (Fase 3 - QuickSort)");
            Console.WriteLine("5. Búsqueda Binaria  (Fase 4 - Indexada O(log n))");
            Console.WriteLine("6. Salir del Sistema");
            Console.WriteLine("=============================================\n");
        }

        private static void EjecutarInsertar()
        {
            Console.WriteLine("\n--- OPCIÓN 1: INSERTAR REGISTRO ---");
            Console.Write("Ingrese ID del registro (numérico): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new FormatException("El ID ingresado debe ser un número entero válido.");
            }

            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine() ?? "Sin Nombre";

            Console.Write("Ingrese Dato / Valor: ");
            string dato = Console.ReadLine() ?? "";

            baseDeDatos.Insertar(new RegistroDatos { Id = id, Nombre = nombre, Dato = dato });
            indiceOrdenado = null; // Invalidar índice desactualizado
            Console.WriteLine($"\n[ÉXITO] Registro con ID {id} insertado correctamente.");
            Pausar();
        }

        private static void EjecutarEliminar()
        {
            Console.WriteLine("\n--- OPCIÓN 2: ELIMINAR REGISTRO POR ID ---");
            if (baseDeDatos.EstaVacia())
            {
                throw new InvalidOperationException("No se pueden eliminar elementos porque la lista está vacía.");
            }

            Console.Write("Ingrese el ID del registro a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new FormatException("El ID debe ser un valor numérico.");
            }

            bool eliminado = baseDeDatos.Eliminar(id);
            if (eliminado)
            {
                indiceOrdenado = null; // Invalidar índice
                Console.WriteLine($"\n[ÉXITO] Nodo con ID {id} desconectado y liberado.");
            }
            else
            {
                Console.WriteLine($"\n[INFORMACIÓN] No se encontró ningún registro con ID {id}.");
            }
            Pausar();
        }

        private static void EjecutarMostrarTodo()
        {
            Console.WriteLine("\n--- OPCIÓN 3: MOSTRAR REGISTROS EN LISTA ---");
            if (baseDeDatos.EstaVacia())
            {
                Console.WriteLine("[INFORMACIÓN] La lista enlazada está actualmente vacía.");
            }
            else
            {
                baseDeDatos.ImprimirLista();
            }
            Pausar();
        }

        private static void EjecutarIndexarYOrdenar()
        {
            Console.WriteLine("\n--- OPCIÓN 4: INDEXAR Y ORDENAR (FASE 3) ---");
            if (baseDeDatos.EstaVacia())
            {
                throw new InvalidOperationException("Debe insertar registros antes de poder indexar y ordenar.");
            }

            indiceOrdenado = baseDeDatos.ObtenerComoArreglo();
            Array.Sort(indiceOrdenado, (a, b) => a.Id.CompareTo(b.Id));
            Console.WriteLine($"\n[ÉXITO] Se han indexado y ordenado {indiceOrdenado.Length} registros por ID.");
            Pausar();
        }

        private static void EjecutarBusquedaBinaria()
        {
            Console.WriteLine("\n--- OPCIÓN 5: BÚSQUEDA BINARIA INDEXADA (FASE 4) ---");
            if (indiceOrdenado == null || indiceOrdenado.Length == 0)
            {
                throw new InvalidOperationException("El índice no está generado. Ejecute primero la Opción 4 (Indexar y Ordenar).");
            }

            Console.Write("Ingrese el ID a buscar: ");
            if (!int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                throw new FormatException("El ID buscado debe ser numérico.");
            }

            // Invocación a la función del contrato de la imagen image_8d61fb.jpg
            var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(indiceOrdenado, idBuscado);

            if (registro != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n✓ [REGISTRO ENCONTRADO]");
                Console.WriteLine($"  ID          : {registro.Id}");
                Console.WriteLine($"  Nombre      : {registro.Nombre}");
                Console.WriteLine($"  Dato        : {registro.Dato}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n✗ [NO ENCONTRADO] El ID {idBuscado} no existe.");
                Console.ResetColor();
            }

            Console.WriteLine($"  Comparaciones realizadas: {comparaciones} (Eficiencia O(log n))");
            Pausar();
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}