using System;

namespace DataCoreEngine
{
    public static class AlgoritmosOrdenamiento
    {
        /// <summary>
        /// SelectionSort — Complejidad O(n²) determinística.
        /// Ordena un arreglo de RegistroDatos in-place por Id.
        /// </summary>
        public static void SelectionSort(RegistroDatos[] datos)
        {
            int n = datos.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int idxMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (datos[j].Id < datos[idxMin].Id)
                    {
                        idxMin = j;
                    }
                }

                if (idxMin != i)
                {
                    RegistroDatos temp = datos[i];
                    datos[i] = datos[idxMin];
                    datos[idxMin] = temp;
                }
            }
        }

        /// <summary>
        /// QuickSort con estrategia de Pivote Central — Complejidad Promedio O(n log n).
        /// </summary>
        public static void QuickSort(RegistroDatos[] datos, int izq, int der)
        {
            if (izq >= der) return;

            int p = Particionar(datos, izq, der);
            QuickSort(datos, izq, p);
            QuickSort(datos, p + 1, der);
        }

        private static int Particionar(RegistroDatos[] datos, int izq, int der)
        {
            int pivotId = datos[(izq + der) / 2].Id;
            int i = izq - 1;
            int j = der + 1;

            while (true)
            {
                do { i++; } while (datos[i].Id < pivotId);
                do { j--; } while (datos[j].Id > pivotId);

                if (i >= j) return j;

                RegistroDatos temp = datos[i];
                datos[i] = datos[j];
                datos[j] = temp;
            }
        }
    }
}