using System;
using System.Collections.Generic;

namespace AlgoritmosBusqueda
{
    public static class BuscadorMatriculas
    {
        /// <summary>
        /// Realiza una búsqueda lineal O(n) sobre el arreglo de estudiantes.
        /// </summary>
        /// <param name="estudiantes">Colección de datos.</param>
        /// <param name="matriculaBuscada">Matrícula a encontrar.</param>
        /// <param name="iteraciones">Parámetro de salida que registra el número total de comparaciones.</param>
        /// <returns>El objeto Estudiante si se encuentra; de lo contrario, null.</returns>
        public static Estudiante BusquedaLineal(List<Estudiante> estudiantes, int matriculaBuscada, out int iteraciones)
        {
            iteraciones = 0;
            for (int i = 0; i < estudiantes.Count; i++)
            {
                iteraciones++;
                if (estudiantes[i].Matricula == matriculaBuscada)
                {
                    return estudiantes[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Realiza una búsqueda binaria O(log n) sobre el arreglo ordenado de estudiantes.
        /// </summary>
        /// <param name="estudiantes">Colección de datos previamente ordenada.</param>
        /// <param name="matriculaBuscada">Matrícula a encontrar.</param>
        /// <param name="iteraciones">Parámetro de salida que registra el número total de comparaciones.</param>
        /// <returns>El objeto Estudiante si se encuentra; de lo contrario, null.</returns>
        public static Estudiante BusquedaBinaria(List<Estudiante> estudiantes, int matriculaBuscada, out int iteraciones)
        {
            iteraciones = 0;
            int izquierda = 0;
            int derecha = estudiantes.Count - 1;

            while (izquierda <= derecha)
            {
                iteraciones++;

                // Optimización para evitar Integer Overflow: (izquierda + derecha) / 2
                int medio = izquierda + (derecha - izquierda) / 2;

                if (estudiantes[medio].Matricula == matriculaBuscada)
                {
                    return estudiantes[medio];
                }

                if (estudiantes[medio].Matricula < matriculaBuscada)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }

            return null;
        }
    }
}