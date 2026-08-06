using System;
using System.Diagnostics;

namespace DataCoreEngine
{
    class Program
    {
        private static TablaDinamica<RegistroDatos> _tabla = new TablaDinamica<RegistroDatos>();
        private static RegistroDatos[]? _arregloCache = null;
        private static bool _estaOrdenado = false;

        static void Main(string[] args)
        {
            int opcion = -1;
            do
            {
                MostrarMenuCLI();
                string? entrada = Console.ReadLine();
                try
                {
                    if (!int.TryParse(entrada, out opcion))
                    {
                        throw new FormatException("La entrada ingresada no es numérica.");
                    }

                    if (opcion < 0 || opcion > 6)
                    {
                        throw new ArgumentOutOfRangeException(nameof(opcion), "Opción fuera de rango [0-6].");
                    }

                    EjecutarOpcion(opcion);
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR] {ex.Message} Ingrese un número entre 0 y 6.");
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR] {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR INESPERADO] {ex.Message}");
                    Console.ResetColor();
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);

            Console.WriteLine("\nSaliendo del sistema DataCore Engine v4.0...");
        }

        private static void MostrarMenuCLI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================================");
            Console.WriteLine("           DataCore Engine v4.0 - Menú CLI       ");
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.WriteLine(" | [1] Insertar nuevo registro                 |");
            Console.WriteLine(" | [2] Mostrar todos los registros             |");
            Console.WriteLine(" | [3] Ordenar con SelectionSort               |");
            Console.WriteLine(" | [4] Ordenar con QuickSort                   |");
            Console.WriteLine(" | [5] Búsqueda binaria por ID                 |");
            Console.WriteLine(" | [6] Eliminar registro por ID                |");
            Console.WriteLine(" | [0] Salir del sistema                       |");
            Console.WriteLine("=================================================");
            Console.Write("Ingrese una opción: ");
        }

        private static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    InsertarRegistro();
                    break;
                case 2:
                    MostrarRegistros();
                    break;
                case 3:
                    EjecutarOrdenamiento(usarQuickSort: false);
                    break;
                case 4:
                    EjecutarOrdenamiento(usarQuickSort: true);
                    break;
                case 5:
                    EjecutarBusquedaBinaria();
                    break;
                case 6:
                    EliminarRegistro();
                    break;
            }
        }

        private static void InsertarRegistro()
        {
            Console.WriteLine("\n--- Insertar Nuevo Registro ---");
            Console.Write("Ingrese ID (entero > 0): ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Ingrese Valor (decimal): ");
            double valor = double.Parse(Console.ReadLine() ?? "0");

            RegistroDatos nuevo = new RegistroDatos(id, nombre, valor);
            _tabla.Agregar(nuevo);

            _estaOrdenado = false; // Invalida el caché
            _arregloCache = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[OK] Registro agregado exitosamente en cabeza O(1).");
            Console.ResetColor();
        }

        private static void MostrarRegistros()
        {
            Console.WriteLine("\n--- Registros en Tabla Dinámica (Heap) ---");
            if (_tabla.Count == 0)
            {
                Console.WriteLine("La tabla está vacía.");
                return;
            }

            foreach (var reg in _tabla)
            {
                Console.WriteLine(reg);
            }
            Console.WriteLine($"Total de registros: {_tabla.Count}");
        }

        private static void EjecutarOrdenamiento(bool usarQuickSort)
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nNo hay datos para ordenar.");
                return;
            }

            _arregloCache = _tabla.ToArray();
            Stopwatch sw = Stopwatch.StartNew();

            if (usarQuickSort)
            {
                AlgoritmosOrdenamiento.QuickSort(_arregloCache, 0, _arregloCache.Length - 1);
                sw.Stop();
                Console.WriteLine($"\n[INFO] Ejecutando QuickSort O(n log n)...");
            }
            else
            {
                AlgoritmosOrdenamiento.SelectionSort(_arregloCache);
                sw.Stop();
                Console.WriteLine($"\n[INFO] Ejecutando SelectionSort O(n²)...");
            }

            _estaOrdenado = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[OK] Arreglo denso materializado y ordenado con éxito.");
            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms ({sw.Elapsed.TotalMicroseconds:F2} µs)");
            Console.ResetColor();
        }

        private static void EjecutarBusquedaBinaria()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa colección está vacía.");
                return;
            }

            if (!_estaOrdenado || _arregloCache == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[AVISO] La colección no estaba ordenada. Ejecutando QuickSort automático...");
                Console.ResetColor();
                _arregloCache = _tabla.ToArray();
                AlgoritmosOrdenamiento.QuickSort(_arregloCache, 0, _arregloCache.Length - 1);
                _estaOrdenado = true;
            }

            Console.Write("\nIngrese el ID a buscar: ");
            int idBuscado = int.Parse(Console.ReadLine() ?? "0");

            int idx = Busqueda.BusquedaBinaria(_arregloCache, idBuscado, out int comparaciones);

            if (idx != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[OK] Registro encontrado en el índice {idx} (Arreglo Denso):");
                Console.WriteLine($"    {_arregloCache[idx]}");
                Console.WriteLine($"[INFO] Búsqueda completada en {comparaciones} comparaciones.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[FAIL] Registro con ID {idBuscado} no encontrado tras {comparaciones} comparaciones.");
                Console.ResetColor();
            }
        }

        private static void EliminarRegistro()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa tabla está vacía.");
                return;
            }

            Console.Write("\nIngrese el ID a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            bool eliminado = _tabla.Eliminar(r => r.Id == id);

            if (eliminado)
            {
                _estaOrdenado = false;
                _arregloCache = null;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[OK] Registro con ID {id} eliminado de la lista enlazada.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[FAIL] No se encontró ningún registro con ID {id}.");
                Console.ResetColor();
            }
        }
    }
}