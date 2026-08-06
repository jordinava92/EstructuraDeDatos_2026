using System;

namespace DataCore.Fase3
{
    public class InteroperabilidadFase3
    {
        public static void OrdenarListaConQuickSort(TablaDinamica lista)
        {
            // 1. Convertir la lista dinámica a arreglo estático usando el nuevo nombre del método
            RegistroDatos[] arreglo = lista.ObtenerComoArreglo();

            // 2. Aplicar el algoritmo de ordenamiento QuickSort de la Fase 1/2
            // AlgoritmosPrevios.QuickSort(arreglo, 0, arreglo.Length - 1);

            // 3. Reconstruir la lista ordenada usando el método de inserción oficial
            ReconstruirLista(lista, arreglo);
        }

        public static void OrdenarListaConSelectionSort(TablaDinamica lista)
        {
            // 1. Convertir la lista dinámica a arreglo estático
            RegistroDatos[] arreglo = lista.ObtenerComoArreglo();

            // 2. Aplicar SelectionSort de la Fase 1/2
            // AlgoritmosPrevios.SelectionSort(arreglo);

            // 3. Reconstruir la lista ordenada
            ReconstruirLista(lista, arreglo);
        }

        private static void ReconstruirLista(TablaDinamica lista, RegistroDatos[] arreglo)
        {
            // Reiniciar la lista insertando cada registro del arreglo ordenado
            foreach (var registro in arreglo)
            {
                lista.InsertarFinal(registro);
            }
        }
    }
}