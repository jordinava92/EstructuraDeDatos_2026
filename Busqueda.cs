namespace DataCoreEngine
{
    public static class Busqueda
    {
        // Búsqueda Binaria exactamente como viene especificada en la memoria técnica
        public static int BusquedaBinaria(RegistroDatos[] arr, int idBuscado)
        {
            int izq = 0;
            int der = arr.Length - 1;

            while (izq <= der)
            {
                int mid = izq + (der - izq) / 2;

                if (arr[mid].Id == idBuscado)
                {
                    return mid; // ¡Encontrado!
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

            return -1; // No encontrado
        }
    }
}