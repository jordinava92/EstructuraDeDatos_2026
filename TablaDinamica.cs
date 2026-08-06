using System;

namespace DataCore.Fase3
{
    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contadorRegistros;

        public TablaDinamica()
        {
            cabeza = null;
            contadorRegistros = 0;
        }

        public int Cantidad => contadorRegistros;

        // Inserción al inicio O(1)
        public void InsertarInicio(RegistroDatos nuevoRegistro)
        {
            if (nuevoRegistro == null) 
                throw new ArgumentNullException(nameof(nuevoRegistro));

            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            contadorRegistros++;
        }

        // Inserción al final O(n)
        public void InsertarFinal(RegistroDatos nuevoRegistro)
        {
            if (nuevoRegistro == null) 
                throw new ArgumentNullException(nameof(nuevoRegistro));

            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);

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

            contadorRegistros++;
        }

        // Eliminación por ID O(n)
        public bool EliminarPorId(int idTarget)
        {
            if (cabeza == null) return false;

            // Caso especial: eliminar la cabeza
            if (cabeza.Dato != null && cabeza.Dato.Id == idTarget)
            {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return true;
            }

            // Recorrido en tándem (anterior y actual)
            NodoRegistro anterior = cabeza;
            NodoRegistro? actual = cabeza.Siguiente;

            while (actual != null)
            {
                if (actual.Dato != null && actual.Dato.Id == idTarget)
                {
                    anterior.Siguiente = actual.Siguiente;
                    contadorRegistros--;
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        // Conversión a Arreglo O(n)
        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                if (actual.Dato != null)
                {
                    resultado[i] = actual.Dato;
                    i++;
                }
                actual = actual.Siguiente;
            }

            return resultado;
        }

        public RegistroDatos? BuscarPorId(int id)
        {
            NodoRegistro? actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato != null && actual.Dato.Id == id)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}