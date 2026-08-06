using System;
using System.Collections;
using System.Collections.Generic;

namespace DataCoreEngine
{
    /// <summary>
    /// Lista simplemente enlazada genérica residente en el Heap.
    /// </summary>
    public class TablaDinamica<T> : IEnumerable<T> where T : struct
    {
        private class Nodo<TDato>
        {
            public TDato Dato { get; set; }
            public Nodo<TDato>? Siguiente { get; set; }

            public Nodo(TDato dato)
            {
                Dato = dato;
                Siguiente = null;
            }
        }

        private Nodo<T>? _cabeza;
        private int _count;

        public int Count => _count;

        public TablaDinamica()
        {
            _cabeza = null;
            _count = 0;
        }

        // Inserción en cabeza — O(1)
        public void Agregar(T dato)
        {
            var nuevoNodo = new Nodo<T>(dato)
            {
                Siguiente = _cabeza
            };
            _cabeza = nuevoNodo;
            _count++;
        }

        // Eliminación por predicado — O(n)
        public bool Eliminar(Func<T, bool> predicado)
        {
            if (_cabeza == null) return false;

            if (predicado(_cabeza.Dato))
            {
                _cabeza = _cabeza.Siguiente;
                _count--;
                return true;
            }

            Nodo<T> actual = _cabeza;
            while (actual.Siguiente != null)
            {
                if (predicado(actual.Siguiente.Dato))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    _count--;
                    return true;
                }
                actual = actual.Siguiente;
            }

            return false;
        }

        // Materialización a arreglo denso — O(n)
        public T[] ToArray()
        {
            T[] resultado = new T[_count];
            Nodo<T>? actual = _cabeza;
            int i = 0;
            while (actual != null)
            {
                resultado[i++] = actual.Dato;
                actual = actual.Siguiente;
            }
            return resultado;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T>? actual = _cabeza;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}