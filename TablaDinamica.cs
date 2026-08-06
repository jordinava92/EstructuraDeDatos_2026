using System;
using System.Collections.Generic;

namespace EstructuraDeDatos_2026
{
    public class Nodo
    {
        public RegistroDatos Dato { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class TablaDinamica
    {
        public Nodo? Cabeza { get; private set; }
        public int Contador { get; private set; }

        public void Agregar(RegistroDatos dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = Cabeza;
            Cabeza = nuevo;
            Contador++;
        }

        public bool Eliminar(int id)
        {
            Nodo? actual = Cabeza;
            Nodo? anterior = null;

            while (actual != null)
            {
                if (actual.Dato.Id == id)
                {
                    if (anterior == null)
                        Cabeza = actual.Siguiente;
                    else
                        anterior.Siguiente = actual.Siguiente;

                    Contador--;
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            return false;
        }

        public RegistroDatos[] ConvertirAArreglo()
        {
            RegistroDatos[] arreglo = new RegistroDatos[Contador];
            Nodo? actual = Cabeza;
            int i = 0;

            while (actual != null && i < Contador)
            {
                arreglo[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }

            return arreglo;
        }
    }
}