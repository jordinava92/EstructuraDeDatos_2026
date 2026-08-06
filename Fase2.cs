namespace EstructuraDeDatos_2026
{
    public class Fase2
    {
        // Contador requerido para instrumentación del Call Stack
        public static int contadorLlamadas = 0;

        public static void QuickSort(RegistroDatos[] arr, int bajo, int alto)
        {
            contadorLlamadas++;

            if (bajo < alto)
            {
                int indicePivote = Particionar(arr, bajo, alto);

                // Llamada recursiva sublista IZQUIERDA
                QuickSort(arr, bajo, indicePivote - 1);

                // Llamada recursiva sublista DERECHA
                QuickSort(arr, indicePivote + 1, alto);
            }
        }

        private static int Particionar(RegistroDatos[] arr, int bajo, int alto)
        {
            // Aquí va la lógica de selección de pivote y reordenamiento
            RegistroDatos pivote = arr[alto];
            int i = (bajo - 1);

            for (int j = bajo; j <= alto - 1; j++)
            {
                if (arr[j].Id < pivote.Id)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, alto);
            return (i + 1);
        }

        private static void Swap(RegistroDatos[] arr, int i, int j)
        {
            RegistroDatos temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}