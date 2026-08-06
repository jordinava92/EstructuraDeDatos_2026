using System;

namespace DataCore.Fase4
{
    /// <summary>
    /// Proporciona métodos para realizar búsquedas indexadas sobre la estructura de datos dinámica.
    /// </summary>
    public class BusquedaIndexada
    {
        /// <summary>
        /// Realiza una búsqueda binaria O(log n) sobre un índice auxiliar ordenado.
        /// </summary>
        /// <param name="tabla">La instancia de la tabla dinámica con los datos.</param>
        /// <param name="idTarget">El ID del registro a buscar.</param>
        /// <param name="comparaciones">Parámetro de salida con el número de comparaciones ejecutadas.</param>
        /// <returns>El registro encontrado o null si no existe.</returns>
        public static Fase3.RegistroDatos? BuscarRegistroIndexado(Fase3.TablaDinamica tabla, int idTarget, out int comparaciones)
        {
            comparaciones = 0;

            // 1. Extraer los datos a un arreglo temporal auxiliar
            Fase3.RegistroDatos[] arregloAuxiliar = tabla.ObtenerComoArreglo();

            if (arregloAuxiliar.Length == 0)
                return null;

            // 2. Garantizar que el arreglo esté ordenado por ID (QuickSort O(n log n))
            Array.Sort(arregloAuxiliar, (a, b) => a.Id.CompareTo(b.Id));

            // 3. Algoritmo de Búsqueda Binaria Clásica O(log n)
            int izquierda = 0;
            int derecha = arregloAuxiliar.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                if (arregloAuxiliar[medio].Id == idTarget)
                {
                    return arregloAuxiliar[medio];
                }

                if (arregloAuxiliar[medio].Id < idTarget)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }

            return null; // No encontrado
        }

        /// <summary>
        /// Búsqueda secuencial lineal O(n) para fines comparativos de rendimiento.
        /// </summary>
        public static Fase3.RegistroDatos? BuscarRegistroLineal(Fase3.TablaDinamica tabla, int idTarget, out int comparaciones)
        {
            comparaciones = 0;
            Fase3.RegistroDatos[] arregloAuxiliar = tabla.ObtenerComoArreglo();

            foreach (var reg in arregloAuxiliar)
            {
                comparaciones++;
                if (reg.Id == idTarget)
                    return reg;
            }

            return null;
        }
    }
}