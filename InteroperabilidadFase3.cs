using System;

namespace DataCore.Fase3
{
    public class InteroperabilidadFase3
    {
        public static void OrdenarListaConQuickSort(TablaDinamica lista)
        {
            // 1. Convertir la lista dinámica a arreglo estático
            RegistroDatos[] arreglo = lista.AArreglo();

            // 2. Aplicar el algoritmo de ordenamiento QuickSort de la Fase 1/2
            // AlgoritmosPrevios.QuickSort(arreglo, 0, arreglo.Length - 1);

            // 3. Reconstruir la lista ordenada
            lista.CargarDesdeArreglo(arreglo);
        }

        public static void OrdenarListaConSelectionSort(TablaDinamica lista)
        {
            // 1. Convertir la lista dinámica a arreglo estático
            RegistroDatos[] arreglo = lista.AArreglo();

            // 2. Aplicar SelectionSort
            // AlgoritmosPrevios.SelectionSort(arreglo);

            // 3. Reconstruir la lista ordenada
            lista.CargarDesdeArreglo(arreglo);
        }
    }
}