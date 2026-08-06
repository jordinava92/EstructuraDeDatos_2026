using System;
using DataCore.Fase3;

namespace DataCore.Fase4
{
    class Program
    {
        private static TablaDinamica baseDeDatos = new TablaDinamica();
        private static int historialOperaciones = 0;

        static void Main(string[] args)
        {
            // Precargar datos iniciales de prueba
            CargarDatosPrueba();

            bool salir = false;
            do
            {
                Console.Clear();
                MostrarEncabezadoMenu();
                Console.WriteLine($"[Registros actuales en memoria: {baseDeDatos.Cantidad}]");
                Console.WriteLine("==================================================");
                Console.WriteLine("[1] Gestión de Registros");
                Console.WriteLine("[2] Módulo de Búsqueda");
                Console.WriteLine("[3] Módulo de Ordenamiento");
                Console.WriteLine("[4] Estadísticas del Sistema");
                Console.WriteLine("[5] Exportar / Importar (Simulación)");
                Console.WriteLine("[0] Salir del sistema");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");

                string? entrada = Console.ReadLine();

                try
                {
                    int opcion = int.Parse(entrada ?? "-1");
                    historialOperaciones++;

                    switch (opcion)
                    {
                        case 1:
                            SubmenuGestionRegistros();
                            break;
                        case 2:
                            SubmenuBusqueda();
                            break;
                        case 3:
                            SubmenuOrdenamiento();
                            break;
                        case 4:
                            MostrarEstadisticas();
                            break;
                        case 5:
                            Console.WriteLine("\n[INFO] Función de Persistencia: Datos exportados a caché en memoria.");
                            PausarPantalla();
                            break;
                        case 0:
                            salir = ConfirmarSalida();
                            break;
                        default:
                            MostrarError("Opción fuera de rango. Por favor ingrese un número del 0 al 5.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    MostrarError("Entrada inválida. Debe ingresar únicamente valores numéricos.");
                }
                catch (Exception ex)
                {
                    MostrarError($"Error inesperado: {ex.Message}");
                }

            } while (!salir);

            Console.WriteLine("\n¡Gracias por utilizar DataCore v4.0! Presione cualquier tecla para terminar.");
        }

        private static void MostrarEncabezadoMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("         DATACORE v4.0 — MENÚ MAESTRO CLI         ");
            Console.WriteLine("==================================================");
        }

        private static void SubmenuGestionRegistros()
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE REGISTROS ---");
            Console.WriteLine("1.1 Insertar nuevo registro");
            Console.WriteLine("1.2 Eliminar registro por ID");
            Console.WriteLine("1.3 Mostrar todos los registros");
            Console.Write("Seleccione una opción: ");

            int subOpcion = int.Parse(Console.ReadLine() ?? "0");

            if (subOpcion == 1)
            {
                Console.Write("Ingrese ID (entero): ");
                int id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ingrese Nombre del Registro: ");
                string nombre = Console.ReadLine() ?? "Sin Nombre";
                Console.Write("Ingrese Monto: ");
                decimal monto = decimal.Parse(Console.ReadLine() ?? "0");

                baseDeDatos.InsertarFinal(new RegistroDatos(id, nombre, monto));
                Console.WriteLine("\n[EXITO] Registro insertado correctamente.");
            }
            else if (subOpcion == 2)
            {
                Console.Write("Ingrese el ID del registro a eliminar: ");
                int id = int.Parse(Console.ReadLine() ?? "0");
                bool eliminado = baseDeDatos.EliminarPorId(id);

                if (eliminado)
                    Console.WriteLine("\n[EXITO] Registro eliminado y memoria liberada.");
                else
                    Console.WriteLine("\n[ALERTA] No se encontró ningún registro con el ID especificado.");
            }
            else if (subOpcion == 3)
            {
                MostrarListaRegistros();
            }
            PausarPantalla();
        }

        private static void SubmenuBusqueda()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO DE BÚSQUEDA ---");
            Console.WriteLine("2.1 Búsqueda Lineal O(n)");
            Console.WriteLine("2.2 Búsqueda Binaria Indexada O(log n)");
            Console.Write("Seleccione una opción: ");

            int subOpcion = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Ingrese el ID a buscar: ");
            int idTarget = int.Parse(Console.ReadLine() ?? "0");

            int comparaciones = 0;
            RegistroDatos? resultado = null;

            if (subOpcion == 1)
            {
                resultado = BusquedaIndexada.BuscarRegistroLineal(baseDeDatos, idTarget, out comparaciones);
                Console.WriteLine("\n--- RESULTADO DE BÚSQUEDA LINEAL O(n) ---");
            }
            else if (subOpcion == 2)
            {
                resultado = BusquedaIndexada.BuscarRegistroIndexado(baseDeDatos, idTarget, out comparaciones);
                Console.WriteLine("\n--- RESULTADO DE BÚSQUEDA BINARIA INDEXADA O(log n) ---");
            }

            if (resultado != null)
            {
                Console.WriteLine($"[ENCONTRADO] ID: {resultado.Id} | Nombre: {resultado.Nombre} | Monto: {resultado.Monto:C}");
            }
            else
            {
                Console.WriteLine($"[NO ENCONTRADO] El ID {idTarget} no existe en la base de datos.");
            }

            Console.WriteLine($"[MÉTRICA] Número de comparaciones realizadas: {comparaciones}");
            PausarPantalla();
        }

        private static void SubmenuOrdenamiento()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO DE ORDENAMIENTO ---");
            Console.WriteLine("3.1 Ordenar por Clave/ID (QuickSort)");
            Console.WriteLine("3.2 Ordenar por Valor/Monto");
            Console.Write("Seleccione una opción: ");
            
            int subOpcion = int.Parse(Console.ReadLine() ?? "0");
            RegistroDatos[] arreglo = baseDeDatos.ObtenerComoArreglo();

            if (subOpcion == 1)
            {
                Array.Sort(arreglo, (a, b) => a.Id.CompareTo(b.Id));
                Console.WriteLine("\n[EXITO] Arreglo ordenado por ID mediante QuickSort.");
            }
            else if (subOpcion == 2)
            {
                Array.Sort(arreglo, (a, b) => a.Monto.CompareTo(b.Monto));
                Console.WriteLine("\n[EXITO] Arreglo ordenado por Monto.");
            }

            foreach (var r in arreglo)
            {
                Console.WriteLine($"ID: {r.Id} | Nombre: {r.Nombre} | Monto: {r.Monto:C}");
            }

            PausarPantalla();
        }

        private static void MostrarEstadisticas()
        {
            Console.Clear();
            Console.WriteLine("--- ESTADÍSTICAS DEL SISTEMA ---");
            Console.WriteLine($"4.1 Total de registros en memoria: {baseDeDatos.Cantidad}");
            
            // Estimación aproximada de memoria en heap (Bytes)
            long memoriaEstimada = baseDeDatos.Cantidad * 64; // ~64 bytes por nodo + struct
            Console.WriteLine($"4.2 Uso estimado de memoria Heap: ~{memoriaEstimada} bytes");
            Console.WriteLine($"4.3 Historial de operaciones realizadas en sesión: {historialOperaciones}");
            PausarPantalla();
        }

        private static void MostrarListaRegistros()
        {
            RegistroDatos[] registros = baseDeDatos.ObtenerComoArreglo();
            Console.WriteLine("\n--- LISTA DE REGISTROS ACTUALES ---");
            if (registros.Length == 0)
            {
                Console.WriteLine("(La lista está vacía)");
                return;
            }

            foreach (var r in registros)
            {
                Console.WriteLine($"ID: {r.Id} | Nombre: {r.Nombre} | Monto: {r.Monto:C}");
            }
        }

        private static void CargarDatosPrueba()
        {
            for (int i = 1; i <= 10; i++)
            {
                baseDeDatos.InsertarFinal(new RegistroDatos(i, $"Transacción-{i}", i * 150.0m));
            }
        }

        private static bool ConfirmarSalida()
        {
            Console.Write("\n¿Está seguro de que desea salir del sistema DataCore v4.0? (S/N): ");
            string? respuesta = Console.ReadLine()?.Trim().ToUpper();
            return respuesta == "S";
        }

        private static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {mensaje}");
            Console.ResetColor();
            PausarPantalla();
        }

        private static void PausarPantalla()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}