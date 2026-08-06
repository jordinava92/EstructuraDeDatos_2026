using System;
using System.Collections.Generic;

namespace DataCore.Fase3
{
    /// <summary>
    /// Estructura de datos lineal dinámica (Lista Simply Enlazada) integrada al motor DataCore.
    /// </summary>
    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contador;

        public TablaDinamica()
        {
            cabeza = null;
            contador = 0;
        }

        /// <summary>
        /// Obtiene el número actual de elementos en la lista.
        /// </summary>
        public int Cantidad => contador;

        /// <summary>
        /// Inserta un nuevo registro al final de la lista.
        /// Operación de complejidad O(1) si se mantiene puntero al cola, o O(n) recorriendo desde cabeza.
        /// </summary>
        public void Insertar(RegistroDatos dato)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(dato);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoRegistro actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            contador++;
        }

        /// <summary>
        /// Busca un registro por su ID.
        /// Complejidad O(n) en el peor caso.
        /// </summary>
        public RegistroDatos? BuscarPorId(int id)
        {
            NodoRegistro? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato != null && actual.Dato.Id == id)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }

            return null; // No encontrado
        }

        /// <summary>
        /// Elimina la primera ocurrencia de un registro coincidente con el ID dado.
        /// Controla adecuadamente el redireccionamiento de punteros y casos borde.
        /// </summary>
        public bool Eliminar(int id)
        {
            if (cabeza == null) return false;

            // Caso borde 1: Eliminar el primer nodo (cabeza)
            if (cabeza.Dato != null && cabeza.Dato.Id == id)
            {
                cabeza = cabeza.Siguiente; // El Garbage Collector se encargará del nodo desreferenciado
                contador--;
                return true;
            }

            // Caso general: Recorrer buscando el elemento previo al que se va a eliminar
            NodoRegistro actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato != null && actual.Siguiente.Dato.Id == id)
                {
                    // Redireccionar el puntero Siguiente del nodo anterior al nodo posterior
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    contador--;
                    return true;
                }
                actual = actual.Siguiente;
            }

            return false; // No se encontró el nodo a eliminar
        }

        /// <summary>
        /// Convierte la lista simplemente enlazada a un arreglo estático de tipo RegistroDatos[].
        /// Necesario para la interoperabilidad con los algoritmos de ordenamiento (QuickSort / SelectionSort).
        /// </summary>
        public RegistroDatos[] AArreglo()
        {
            RegistroDatos[] arreglo = new RegistroDatos[contador];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                if (actual.Dato != null)
                {
                    arreglo[i] = actual.Dato;
                    i++;
                }
                actual = actual.Siguiente;
            }

            return arreglo;
        }

        /// <summary>
        /// Reconstruye la lista a partir de un arreglo estático (útil tras realizar un ordenamiento).
        /// </summary>
        public void CargarDesdeArreglo(RegistroDatos[] arreglo)
        {
            cabeza = null;
            contador = 0;

            foreach (var registro in arreglo)
            {
                Insertar(registro);
            }
        }
    }
}