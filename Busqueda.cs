namespace DataCoreEngine
{
    public static class Busqueda
    {
        /// <summary>
        /// Búsqueda Binaria Iterativa sobre arreglo previamente ordenado — Complejidad O(log n).
        /// </summary>
        /// <returns>Índice del elemento si se encuentra; -1 en caso contrario.</returns>
        public static int BusquedaBinaria(RegistroDatos[] arr, int idBuscado, out int comparaciones)
        {
            comparaciones = 0;
            int izq = 0;
            int der = arr.Length - 1;

            while (izq <= der)
            {
                comparaciones++;
                int mid = izq + (der - izq) / 2;

                if (arr[mid].Id == idBuscado)
                {
                    return mid;
                }

                if (arr[mid].Id < idBuscado)
                {
                    izq = mid + 1;
                }
                else
                {
                    der = mid - 1;
                }
            }

            return -1;
        }
    }
}
