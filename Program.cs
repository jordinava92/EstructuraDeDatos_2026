using System;
using System.Diagnostics;

namespace DataCoreEngine
{
    class Program
    {
        private static TablaDinamica<RegistroDatos> _tabla = new TablaDinamica<RegistroDatos>();
        private static RegistroDatos[]? _arregloDenso = null;
        private static bool _arregloOrdenado = false;

        static void Main(string[] args)
        {
            EjecutarMenu();
        }

        private static void EjecutarMenu()
        {
            int opcion = -1;
            do
            {
                MostrarMenu();
                string? entrada = Console.ReadLine();
                try
                {
                    opcion = int.Parse(entrada ?? "");

                    if (opcion < 0 || opcion > 6)
                    {
                        throw new ArgumentOutOfRangeException(nameof(opcion), "Opción fuera de rango [0-6].");
                    }

                    DespacharOpcion(opcion);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n[ERROR] Entrada no numérica. Ingrese un número entre 0 y 6.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"\n[ERROR] {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERROR] {ex.Message}");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);

            Console.WriteLine("\nSaliendo del sistema...");
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("|===========================================|");
            Console.WriteLine("|       DataCore Engine v4.0 — Menú CLI     |");
            Console.WriteLine("|===========================================|");
            Console.WriteLine("| [1] Insertar nuevo registro               |");
            Console.WriteLine("| [2] Mostrar todos los registros           |");
            Console.WriteLine("| [3] Ordenar con SelectionSort             |");
            Console.WriteLine("| [4] Ordenar con QuickSort                 |");
            Console.WriteLine("| [5] Búsqueda binaria por ID               |");
            Console.WriteLine("| [6] Eliminar registro por ID              |");
            Console.WriteLine("| [0] Salir del sistema                     |");
            Console.WriteLine("|===========================================|");
            Console.Write("Ingresa una opción: ");
        }

        private static void DespacharOpcion(int opcion)
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
                    OrdenarSelectionSort();
                    break;
                case 4:
                    OrdenarQuickSort();
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
            Console.Write("Ingrese ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Ingrese Valor: ");
            double valor = double.Parse(Console.ReadLine() ?? "0");

            RegistroDatos nuevo = new RegistroDatos(id, nombre, valor);
            _tabla.Agregar(nuevo);

            // Al modificar la lista, el arreglo denso previo queda desactualizado
            _arregloOrdenado = false;
            _arregloDenso = null;

            Console.WriteLine("[OK] Registro insertado en la lista.");
        }

        private static void MostrarRegistros()
        {
            Console.WriteLine("\n--- Registros Almacenados ---");
            if (_tabla.Count == 0)
            {
                Console.WriteLine("No hay registros.");
                return;
            }

            foreach (var item in _tabla)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total: {_tabla.Count} registros.");
        }

        private static void OrdenarSelectionSort()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa colección está vacía.");
                return;
            }

            _arregloDenso = _tabla.ToArray();
            Stopwatch sw = Stopwatch.StartNew();
            AlgoritmosOrdenamiento.SelectionSort(_arregloDenso);
            sw.Stop();

            _arregloOrdenado = true;
            Console.WriteLine($"\n[INFO] SelectionSort ejecutado en {sw.ElapsedMilliseconds} ms ({sw.Elapsed.TotalMicroseconds:F2} µs).");
            Console.WriteLine("[OK] Arreglo denso ordenado.");
        }

        private static void OrdenarQuickSort()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa colección está vacía.");
                return;
            }

            _arregloDenso = _tabla.ToArray();
            Stopwatch sw = Stopwatch.StartNew();
            AlgoritmosOrdenamiento.QuickSort(_arregloDenso, 0, _arregloDenso.Length - 1);
            sw.Stop();

            _arregloOrdenado = true;
            Console.WriteLine($"\n[INFO] QuickSort ejecutado en {sw.ElapsedMilliseconds} ms ({sw.Elapsed.TotalMicroseconds:F2} µs).");
            Console.WriteLine("[OK] Arreglo denso ordenado.");
        }

        private static void EjecutarBusquedaBinaria()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa colección está vacía.");
                return;
            }

            // Validación estricta según requerimiento de la Memoria Técnica
            if (!_arregloOrdenado || _arregloDenso == null)
            {
                Console.WriteLine("\n[INFO] Convirtiendo lista a arreglo denso...");
                _arregloDenso = _tabla.ToArray();
                Console.WriteLine("[INFO] Ejecutando Búsqueda Binaria...");
                Console.WriteLine("[INFO] Ordenando internamente con QuickSort...");
                AlgoritmosOrdenamiento.QuickSort(_arregloDenso, 0, _arregloDenso.Length - 1);
                _arregloOrdenado = true;
            }

            Console.Write("\nIngresa el ID a buscar: ");
            int idBuscado = int.Parse(Console.ReadLine() ?? "0");

            int idx = Busqueda.BusquedaBinaria(_arregloDenso, idBuscado);

            if (idx != -1)
            {
                Console.WriteLine($"\n[OK] Registro encontrado en índice {idx}");
                Console.WriteLine($"     Id     : { _arregloDenso[idx].Id}");
                Console.WriteLine($"     Nombre : { _arregloDenso[idx].Nombre}");
                Console.WriteLine($"     Valor  : { _arregloDenso[idx].Valor}");
            }
            else
            {
                Console.WriteLine($"\n[FAIL] No se encontró el registro con ID {idBuscado}.");
            }
        }

        private static void EliminarRegistro()
        {
            if (_tabla.Count == 0)
            {
                Console.WriteLine("\nLa colección está vacía.");
                return;
            }

            Console.Write("\nIngresa el ID a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            bool eliminado = _tabla.Eliminar(r => r.Id == id);

            if (eliminado)
            {
                _arregloOrdenado = false;
                _arregloDenso = null;
                Console.WriteLine($"\n[OK] Registro con ID {id} eliminado.");
            }
            else
            {
                Console.WriteLine($"\n[FAIL] No se encontró el ID {id}.");
            }
        }
    }
}