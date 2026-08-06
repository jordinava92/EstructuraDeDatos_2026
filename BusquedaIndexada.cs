using System;

namespace DataCore.Fase4
{
    /// <summary>
    /// Proporciona algoritmos de búsqueda sobre arreglos de datos indexados.
    /// </summary>
    public static class BusquedaIndexada
    {
        /// <summary>
        /// Realiza una búsqueda binaria O(log n) sobre un arreglo previamente ordenado ascendente por ID.
        /// </summary>
        /// <param name="arrOrdenado">Arreglo de RegistroDatos ordenado por ID de menor a mayor.</param>
        /// <param name="idBuscado">El ID del registro a buscar (debe ser un ID válido).</param>
        /// <returns>Una tupla conteniendo el registro encontrado (o null) y el total de comparaciones realizadas.</returns>
        public static (RegistroDatos? registro, int comparaciones) BuscarRegistroIndexado(RegistroDatos[]? arrOrdenado, int idBuscado)
        {
            // Precondición 2: Arreglo no nulo y sin elementos (Caso borde n = 0)
            if (arrOrdenado == null || arrOrdenado.Length == 0)
            {
                return (null, 0);
            }

            int izq = 0;
            int der = arrOrdenado.Length - 1;
            int comparaciones = 0;

            while (izq <= der)
            {
                // Prevención de overflow de entero para colecciones grandes
                int medio = izq + (der - izq) / 2;
                comparaciones++;

                if (arrOrdenado[medio].Id == idBuscado)
                {
                    return (arrOrdenado[medio], comparaciones);
                }
                else if (arrOrdenado[medio].Id < idBuscado)
                {
                    izq = medio + 1;
                }
                else
                {
                    der = medio - 1;
                }
            }

            return (null, comparaciones);
        }

        /// <summary>
        /// Búsqueda lineal O(n) sobre arreglo para fines comparativos de rendimiento.
        /// </summary>
        public static (RegistroDatos? registro, int comparaciones) BuscarRegistroLineal(RegistroDatos[]? arreglo, int idBuscado)
        {
            if (arreglo == null || arreglo.Length == 0)
            {
                return (null, 0);
            }

            int comparaciones = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                comparaciones++;
                if (arreglo[i].Id == idBuscado)
                {
                    return (arreglo[i], comparaciones);
                }
            }

            return (null, comparaciones);
        }
    }
}